using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private bool paused;
    [Header("Keybinds")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;


    [SerializeField] private Transform orientation;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private MonologueData kencingMonologue;

    public bool isSober = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        if (GlobalGameManager.Instance.lastOpenWorldPosition != Vector3.zero)
        {
            transform.position = GlobalGameManager.Instance.lastOpenWorldPosition;
            GlobalGameManager.Instance.CheckOpenScene();
        }
        else {
            GlobalGameManager.Instance.CheckOpenScene();
        }
    }
   
    public void Pause()
    {
        paused = true;
        rb.velocity = Vector3.zero;
        horizontalInput = 0;
        verticalInput = 0;
        anim.SetBool("Lari", false);
    }
    public void Continue()
    {
        paused = false;
    }
    public void KenaTai()
    {
       StartCoroutine(KenaTaiDelay());
    }
	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Tai"))
        {
            KenaTai();
            other.gameObject.SetActive(false);
        }
	}
	private IEnumerator KenaTaiDelay()
    {
        rb.mass = 15;
        yield return new WaitForSeconds(2f);
        rb.mass = 3;
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
        if (isSober)
        {
            MovePlayer();
        }
        else
        {
            MovePlayerDrunk();
        }
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
        if (paused)
            return;
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (isSober)
        {
            if (horizontalInput == 0 && verticalInput == 0)
            {
                anim.SetBool("Lari", false);
            }
            else
            {
                anim.SetBool("Lari", true);
            }
        }
        else if(!isSober)
        {
            if (horizontalInput == 0 && verticalInput == 0)
            {
                anim.SetBool("Walk", false);
            }
            else
            {
                anim.SetBool("Walk", true);
            }
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

    private void MovePlayerDrunk()
    {
        if(verticalInput > 0) verticalInput =-1;
        else if(verticalInput < 0) verticalInput = 1;

        if (horizontalInput > 0) horizontalInput = -1;
        else if (horizontalInput < 0) horizontalInput = 1;

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
            rb.AddForce(moveDirection.normalized * (moveSpeed * 0.5f) * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * (moveSpeed * 0.5f) * airMultiplier, ForceMode.Force);
    }

    public void MakePlayerDrunk(bool isPlayerSober)
    {
        isSober = isPlayerSober;
    }
    public void SoberTimer()
    {
        StartCoroutine(SoberDelay());
    }
    private IEnumerator SoberDelay()
    {
        yield return new WaitForSeconds(10);
        //Monologue Pengen Kencing
        OpenWorldManager.Instance.PlayMonologue(kencingMonologue);
        yield return new WaitForSeconds(5);
        GlobalGameManager.Instance.lastOpenWorldPosition = this.transform.position; ;
        SceneManager.LoadScene("Kencing1");

    }
}
