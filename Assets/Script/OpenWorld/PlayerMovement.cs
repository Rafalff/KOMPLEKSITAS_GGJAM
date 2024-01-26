using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
 
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
        MyInput();
	}
	private void FixedUpdate()
	{
        MovePlayer();
	}
	private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }



}
