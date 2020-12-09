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

    void Update()
    {
       if (isMoving == false)
        {
            StartCoroutine(Movement());
        } 
       //Rotation to the left
       if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
       //rotation to the right
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        //employees are moving
        if (isWalking == true)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }


    }

    IEnumerator Movement()
    {
        //Intervals of time between walking, waiting, and rotating
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 2);
        int rotateRorL = Random.Range(1, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 6);

        isMoving = true;
        //based on the range number, determines how long each employee has to move & rotate
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        
        if(rotateRorL == 1)
        {
            //when walking forward there is no rotation
            //stops employees from constantly rotating
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
        //restarts the couroutine over again
        isMoving = false;

    }
}
