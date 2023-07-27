using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Player : MonoBehaviour,IThrowBall
{
    [SerializeField] BallSpawner ballSpawner;
    CharacterController characterController;

    [Header("Movement")]
    [Space]
    public float moveSpeed;
    public Transform orientation;
    [SerializeField] float groundDrag;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCoolDown;
    [SerializeField] float airMultiplier;
    [SerializeField] bool isReadyToJump;
    private float horizontalInput;
    private float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    [Header("Keybinds")]
    [Space]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    [Space]
    public float playerHeight;
    public LayerMask isItGround;
    [SerializeField] bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        QualitySettings.pixelLightCount = 6;
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Player specific throw abstract 
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            Throw();
        }
#endif
        // Getting Player Input Values
        PlayerInput();
        // Checks if the player is grounded using Raycast and changes the drag according to the isGrounded bool
        CheckIfGrounded();
        // Limits the player speed when it goes beyond a certain speed due to forces acting on it
        SpeedControl(); 
    }
    void FixedUpdate()
    {
        // Deals with the First Person movement
        Move();
    }
    void PlayerInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetKey(jumpKey) && isGrounded && isReadyToJump)
        {
            isReadyToJump = false;
            Jump();
            Invoke(nameof(ResetJump),jumpCoolDown);
        }
    }
    void Move()
    {
        moveDirection = orientation.forward*verticalInput + orientation.right*horizontalInput;
        if(isGrounded)
            rb.AddForce(moveDirection.normalized*moveSpeed*10f,ForceMode.Force);
        else
            rb.AddForce(moveDirection.normalized*moveSpeed*10f*airMultiplier,ForceMode.Force);
    }
    public void CheckIfGrounded()
    {
        isGrounded = Physics.Raycast(transform.position,Vector3.down,playerHeight*0.5f+0.2f,isItGround);
        if(isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x,0,rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitSpeed = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitSpeed.x,rb.velocity.y,limitSpeed.z);
        }
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x,0,rb.velocity.z);
        rb.AddForce(transform.up*jumpForce,ForceMode.Impulse);
    }
    void ResetJump()
    {
        isReadyToJump = true;
    }
    public void Throw()
    {
        ballSpawner.ThrowBall();
    }

}
