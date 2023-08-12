using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; //Forward and Backward Speed
    public float strafeSpeed; //Left and Right Speed
    public float jumpForce;
    public Rigidbody pelvis;
    public bool isGrounded;
    public Animator animator;

    void Start()
    {
        pelvis = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        int heading = (Input.GetKey(KeyCode.W) ? 1:0) - (Input.GetKey(KeyCode.S) ? 1:0);
        int strafe= (Input.GetKey(KeyCode.D) ? 1:0) - (Input.GetKey(KeyCode.A) ? 1:0);
        //Debug.Log(heading + strafe);
        animator.SetBool("isWalk", heading != 0); // set walking if either only one of W or S are pressed, otherwise false
        animator.SetBool("isSideLeft",strafe == -1); // set left if only A is pressed, not D as well
        animator.SetBool("isSideRight",strafe == 1); // set right if only D is pressed, not A as well
        
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                pelvis.AddForce((-pelvis.transform.up * speed*1.5f));
                animator.SetBool("isRun",true);
            }
            else
            {
                pelvis.AddForce((-pelvis.transform.up * speed));
                animator.SetBool("isRun",false);
            }
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            pelvis.AddForce((pelvis.transform.up * speed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            pelvis.AddForce((pelvis.transform.forward * strafeSpeed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            pelvis.AddForce((-pelvis.transform.forward * strafeSpeed));
        }

        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                pelvis.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
    }
    
}
