using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private double startScore = 0;
    private double currentScore = 0;
    public GameObject[] employees;
    [SerializeField]
    Text scoreDisplay;
    private Color employeeColor;
    

    void Start()
    {
        scoreDisplay.text = startScore.ToString("Score: " + startScore);
    }

    void Update()
    {   
        scoreDisplay.text = currentScore.ToString("Score: " + currentScore);
        EmployeeProductivity();
    }

    void EmployeeProductivity()
    {
        foreach (GameObject employee in employees)
        {
            employeeColor = employee.gameObject.GetComponent<MeshRenderer>().material.color;

            if (employeeColor == Color.cyan)
            {
                Debug.Log("Score is increasing based on productivity.");
                currentScore = currentScore + 1;
                Debug.Log(currentScore);
            }

            else if (employeeColor == Color.red)
            {
                Debug.Log("Score is decreasing based on productivity.");
                currentScore = currentScore - 1;
                Debug.Log(currentScore);
            }
        }
    }
}
