using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected virtual void OnEnter() 
    {
        StartCoroutine("OnCurrentState");
    }

    protected void OnExit() 
    {
        StopAllCoroutines();
    }

    protected abstract IEnumerable OnCurrentState();
}
