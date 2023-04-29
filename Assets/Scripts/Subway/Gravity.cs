using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float gravity = 10;
    [SerializeField] string tagg="Ground";
    private float velocity;
    public float Jump { get { return velocity; } set {  velocity = value; } }
    public float TheGravity { get { return gravity; } set {  gravity = value; } }
    private Rigidbody rb;
    private bool isGrounded;
    public bool IsGrounded { get { return isGrounded; } private set { } }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!isGrounded)
        {
            velocity-=gravity*Time.deltaTime;

        }else if (isGrounded) 
        {
            velocity = Mathf.MoveTowards(velocity,-1f,40*Time.deltaTime) ;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == tagg)
        {
            isGrounded = true;
            print("collided");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == tagg) 
        {
            isGrounded = false;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity= new Vector3(rb.position.x, velocity, rb.position.z);
    }
}
