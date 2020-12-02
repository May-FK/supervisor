using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityStateMachine : MonoBehaviour
{
    public GameObject employee;
    public GameObject supervisor;
    
    public float DTReset = 5.0f;
    private float DTimer;
    private float DChance = .25f;

    float lowChance = 0.15f;
    float medChance = 0.3f;
    float highChance = 0.5f;

    public enum ProductivityState
    {
        Productive,
        Distracted,
        Social
    }

    public MoodStateMachine MoodState;
    private ProductivityState CurrentState;

    // Start is called before the first frame update
    void Start()
    {
        DTimer = DTReset;
        CurrentState = ProductivityState.Productive;
    }

    // Update is called once per frame
    void Update()
    {
        RunCurrentState();
        Chance();
    }

    public IEnumerator ProductiveState()
    {
        Debug.Log("Employee is being Productive.");
        gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
        DistractedTimer();
        //gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        yield return null;
    }

    //Employee turns cyan if in cheerful state
    public IEnumerator DistractedState()
    {
        Debug.Log("Employee is distracted");
        Interact();
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        // gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
        yield return null;
    }

    //Employee turns red if in annoyed state
    public IEnumerator SocialState()
    {
        Debug.Log("Employee is being social.");
        Interact();
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        // gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return null;
    }

    private void RunCurrentState()
    {
        switch (CurrentState)
        {
            case ProductivityState.Productive:
                StartCoroutine("ProductiveState");
                break;

            case ProductivityState.Distracted:
                StartCoroutine("DistractedState");
                break;

            case ProductivityState.Social:
                StartCoroutine("SocialState");
                break;
        }
    }

    private void Interact()
    {
        if (Vector3.Distance(supervisor.transform.position, employee.transform.position) < 5)
        {
            //Employee moodnum increases every time the player praises them
            if (Input.GetKeyDown(KeyCode.Q))
            {
            }

            //Employee moodnum decreases every time the player reprimands them
            if (Input.GetKeyDown(KeyCode.E))
            {
                CurrentState = ProductivityState.Productive;
            }
        }
    }

    private void Chance()
    {
        if(MoodState.moodNum >= 5)
        {
            DChance = lowChance;
        }

        else if (MoodState.moodNum <= -5)
        {
            DChance = highChance;
        }

        else
        {
            DChance = medChance;
        }
    }

    private void DistractedTimer()
    {
        
        if (DTimer <= 0f)
        {
            float chance = Random.Range(0f, 1f);
            
            if(chance <= DChance)
            {
                CurrentState = ProductivityState.Distracted;
            }

            DTimer = DTReset;
        }

        else
        {
            DTimer -= Time.deltaTime;
        }
    }
}
