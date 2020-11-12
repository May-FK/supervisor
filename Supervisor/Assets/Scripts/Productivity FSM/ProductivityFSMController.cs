using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityFSMController : MonoBehaviour
{
    public enum ProductivityState
    {
        Productive,
        Distracted,
        Social
    }

    private ProductivityState CurrentState;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = ProductivityState.Productive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RunCurrentState()
    {
        switch (CurrentState)
        {
            case ProductivityState.Productive:
                break;

            case ProductivityState.Distracted:
                break;

            case ProductivityState.Social:
                break;
        }
    }
}
