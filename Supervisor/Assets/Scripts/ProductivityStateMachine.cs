using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityStateMachine : MonoBehaviour
{
    public enum ProductivityState
    {
        Productive,
        Distracted,
        Social
    }

    private MoodStateMachine MoodState;
    private ProductivityState CurrentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RunCurrentState();
    }

    public IEnumerator ProductiveState()
    {
        Debug.Log("Employee is being Productive.");
        //gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        yield return null;
    }

    //Employee turns cyan if in cheerful state
    public IEnumerator DistractedState()
    {
        Debug.Log("Employee is distracted");
       // gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
        yield return null;
    }

    //Employee turns red if in annoyed state
    public IEnumerator SocialState()
    {
        Debug.Log("Employee is being social.");
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
}
