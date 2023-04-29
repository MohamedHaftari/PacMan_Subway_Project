using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    private float MoveZ;
   private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveZ = Input.GetAxis("Horizontal");

        //   rb.AddForce(rb.velocity.x, rb.velocity.y, MoveX * speed);
       

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, MoveZ * speed );
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "C")
        {
            SceneManager.LoadScene(0);
        }
    }
}
