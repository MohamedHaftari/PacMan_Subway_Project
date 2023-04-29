using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exits : MonoBehaviour
{
    public float speed = 5f;
    public Transform leftBoundary; // Collider for the left boundary
    public Transform rightBoundary; // Collider for the right boundary
    private bool isEnterRight;
    private bool isEnterLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void OnTriggerEnter(Collider other)
    {
       
        if ( other.gameObject.CompareTag("Left") && !isEnterLeft )
        {
            Debug.Log("Left");
           isEnterLeft= true;

            // transform.localScale = new Vector3(-1, 1, 1); // Flip Pac-Man horizontally
            transform.position = new Vector3(rightBoundary.position.x, transform.position.y, transform.position.z);
        }

        /*
               // Move Pac-Man to the left if he is currently moving to the right and has collided with the right boundary
                if ( other.gameObject.CompareTag("Right") && !isEnterRight)
               {
                   Debug.Log("Right");
                   transform.position = new Vector3(leftBoundary.position.x, transform.position.y, transform.position.z);
                  isEnterRight=true;

                   //transform.localScale = new Vector3(1, 1, 1); // Flip Pac-Man back to his original orientation
               }
         */
    }
    private void OnTriggerExit(Collider other)
    {
        /*
        if (other.gameObject.CompareTag("Left") && isEnterLeft)
        {
            isEnterLeft = false;
        }

        else if (other.gameObject.CompareTag("Right") && isEnterRight)
        {
            isEnterRight = false;
        }
        */

    }
}


