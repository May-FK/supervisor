using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeMovement : MonoBehaviour
{
    [SerializeField]
    public float Speed = 0f;
    [SerializeField]
    public float rotationSpeed = 0f;

    private bool isWalking = false;
    private bool isRotatingRight = false;
    private bool isRotatingLeft = false;
    private bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
       if (isMoving == false)
        {
            StartCoroutine(Movement());
        } 

       if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }

        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }

        if (isWalking == true)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }


    }

    IEnumerator Movement()
    {
        int rotationTime = Random.Range(1, 4);
        int rotateWait = Random.Range(1, 5);
        int rotateRorL = Random.Range(1, 5);
        int walkWait = Random.Range(1, 5);
        int walkTime = Random.Range(1, 6);

        isMoving = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        
        if(rotateRorL == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        if (rotateRorL == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }

        isMoving = false;

    }
}
