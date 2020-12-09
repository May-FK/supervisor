using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showcontrols : MonoBehaviour
{
    public GameObject controls;

    void Start()
    {
        controls.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed.");
            ShowControls();
        }
        else
        {
            controls.SetActive(false);
        }
    }

    public void ShowControls()
    {
        controls.SetActive(true);
    }
}
