using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodStateMachine : MonoBehaviour
{
    //Determines employee mood - higher is happier, lower is angrier
    public int moodNum;
    protected int increment;
    public GameObject employee;

    //employee mood states
    protected enum MoodState
    {
        Neutral,
        Cheerful,
        Annoyed
    }

    protected MoodState moodState;

    //On start, the employee's mood is picked at random
    void Start()
    {
        moodNum = Random.Range(-20,20);
        
        Debug.Log("Employee's mood number is " + moodNum);
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    void Update()
    {
        increment = Random.Range(1,5);
        
        if (moodNum >= 5)
        {
            StartCoroutine("CheerfulState");
        }

        else if (moodNum <= -5)
        {
            StartCoroutine("AnnoyedState");
        }

        else
        {
            StartCoroutine("NeutralState");
        }

        //Employee moodnum increases by 2 every time the player praises them
        if (Input.GetKeyDown(KeyCode.Q))
        {
            moodNum = moodNum + increment;
        }

        //Employee moodnum decreases by 2 every time the player reprimands them
        if (Input.GetKeyDown(KeyCode.E))

        {
            moodNum = moodNum - increment;
        }
    }

    //Employee turns yellow if in a neutral state
    public IEnumerator NeutralState()
    {
        Debug.Log("Employee feels neutral.");
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        while (moodState == MoodState.Neutral) {
            yield return null;
        }
    }

    //Employee turns cyan if in cheerful state
    public IEnumerator CheerfulState()
    {
        Debug.Log("Employee is feeling cheerful!");
        gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
        while (moodState == MoodState.Cheerful) {
            yield return null;
        }
    }

    //Employee turns red if in annoyed state
    public IEnumerator AnnoyedState() 
    {
        Debug.Log("Employee is feeling annoyed.");
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        while (moodState == MoodState.Annoyed) {
            yield return null;
        }
    }
    
}
