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
    [Tooltip("Represents the forward direction of the player on only the Y axis")]
    public Transform orientation;
    [Tooltip("Amount of drag to be added to reduce slide while moving")]
    [SerializeField] float groundDrag;
    [Tooltip("Amount of upward force for jump action")]
    [SerializeField] float jumpForce;
    [Tooltip("Time until which jump can be reused")]
    [SerializeField] float jumpCoolDown;
    [Tooltip("Amount of air movement while moving in mid air")]
    [SerializeField] float airMultiplier;
    [SerializeField] bool isReadyToJump;
    private float horizontalInput;
    private float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    [Header("Keybinds")]
    [Space]
    [Tooltip("Key Input that calls the Jump Action")]
    public KeyCode jumpKey = KeyCode.Space;
    public Joystick joystick;

    [Header("Ground Check")]
    [Space]
    [Tooltip("height of the player, used to set the length of the raycast for ground detection")]
    public float playerHeight;
    [Tooltip("Sets the ground layer that is needed for ground detection")]
    public LayerMask isItGround;
    [SerializeField] bool isGrounded;
    [Header("Networks")]
    [Space]
    [SerializeField] PhotonView photonView;

    [Header("UI")]
    [Space]
    [SerializeField] GameObject canvas;
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
       
        if(photonView.IsMine)
        {
            // Getting Player Input Values
            PlayerInput();
            // Checks if the player is grounded using Raycast and changes the drag according to the isGrounded bool
            CheckIfGrounded();
            // Limits the player speed when it goes beyond a certain speed due to forces acting on it
            SpeedControl(); 
            canvas.SetActive(true);
        }
        
    }
    void FixedUpdate()
    {
        // Deals with the First Person movement
        Move();
    }
    void PlayerInput()
    {
#if UNITY_EDITOR
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
#else
        verticalInput = joystick.Vertical;
        horizontalInput = joystick.Horizontal;
#endif
        // Checks for the possibility and Input for jump
        if(Input.GetKey(jumpKey) && isGrounded && isReadyToJump)
        {
            isReadyToJump = false;
            Jump();
            // Continuous Jump if the JumpKey is Held down
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
