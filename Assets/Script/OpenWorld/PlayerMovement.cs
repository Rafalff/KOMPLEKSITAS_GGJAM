using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator anim;

    [Header("GroundCheck")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool grounded;
    [SerializeField] private float groundDrag;


    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    [SerializeField] private bool readyToJump;
    [SerializeField] private bool canJump;
    [Header("Keybinds")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;


    [SerializeField] private Transform orientation;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x,0,rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        anim.SetTrigger("Lompat");
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput == 0 && verticalInput == 0)
        {
            anim.SetBool("Lari", false);
        }
        else {
            anim.SetBool("Lari", true);
        }

        if (Input.GetKey(jumpKey) && readyToJump && grounded && canJump)
        {
            readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }



}
