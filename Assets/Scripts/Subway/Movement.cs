using MyLibrary;
using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //[SerializeField] float rbPosition;
    private CapsuleCollider capsuleCollider;
    [SerializeField] float step;
    [SerializeField] Animator animator;
    public float Step { get { return step; } set { step = value; } }
    [SerializeField] float jump;
    [SerializeField] float smoothness;
    [SerializeField] float crouchTime = .3f;
    [SerializeField] float crouchCapsulHeight;
    [SerializeField] float crouchCapsulYcenter;
    private float initialCapsulHeight;
    private float initialCapsulYcenter;
    SwipeDetector swipeDetectorScript;
    Gravity gravityScript;
    private float position;
    private Rigidbody rb;
    private MyPosition pos = MyPosition.center;
    private bool canCrouch;

    private void Start()
    {
        canCrouch = true;
        capsuleCollider = GetComponent<CapsuleCollider>();
        initialCapsulHeight = capsuleCollider.height;
        initialCapsulYcenter = capsuleCollider.center.y;
        rb = GetComponent<Rigidbody>();
        swipeDetectorScript = GetComponent<SwipeDetector>();
        gravityScript = GetComponent<Gravity>();
    }
    void Update()
    {
        #region X Movement
        if (Input.GetButtonDown("Right") || swipeDetectorScript.Xdir == MyXdirection.right)
        {
            print("x");
            if (pos == MyPosition.center)
            {
                position += step;
                pos = MyPosition.right;

            }
            else if (pos == MyPosition.left)
            {
                position += step;
                pos = MyPosition.center;

            }
        }
        else if (Input.GetButtonDown("Left") || swipeDetectorScript.Xdir == MyXdirection.left)
        {
            print("x");
            if (pos == MyPosition.center)
            {
                position -= step;
                pos = MyPosition.left;
            }
            else if (pos == MyPosition.right)
            {
                position -= step;
                pos = MyPosition.center;
            }
        }
        #endregion
        #region Y Movement
        if (Input.GetButtonDown("Top") || swipeDetectorScript.Ydir == MyYdirection.top)
        {
            if (gravityScript.IsGrounded)
            {
                gravityScript.Jump = jump;
               //animator.SetBool("running", false);
               //animator.SetBool("jumping", true);

            }
        }
        else if ((Input.GetButtonDown("Down") || swipeDetectorScript.Ydir == MyYdirection.down) && canCrouch)
        {
            canCrouch = false;
            StartCoroutine(Crouch());
        }
        #endregion

        /* if (position != rbPosition)
         {
             rbPosition= Mathf.MoveTowards(rbPosition, position, smoothness*Time.deltaTime);
         }*/
        if (gravityScript.IsGrounded)
        {
            animator.SetBool("running", true);
            animator.SetBool("jumping", false);
        }
        else
        {
            animator.SetBool("running", false);
            animator.SetBool("jumping", true);
        }


    }
    IEnumerator Crouch()
    {
        // capsuleCollider.height = crouchCapsulHeight;
        // capsuleCollider.center=new Vector3 (0, crouchCapsulYcenter, 0);
       // transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
       // transform.position = new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z);
       
        gravityScript.TheGravity *= 3;
        yield return new WaitForSeconds(crouchTime);
        // capsuleCollider.height = initialCapsulHeight;
        // capsuleCollider.center = new Vector3(0, initialCapsulYcenter, 0);
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
        //transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
        gravityScript.TheGravity /= 3;
        canCrouch = true;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(Vector3.MoveTowards(new Vector3(rb.position.x, transform.position.y, transform.position.z),
           new Vector3(position, rb.position.y, transform.position.z), smoothness));
        // rb.MovePosition(new Vector3( rbPosition,rb.position.y,rb.position.z));
    }
}


