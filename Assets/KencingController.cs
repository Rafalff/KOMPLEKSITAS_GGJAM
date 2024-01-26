using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KencingController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f; // Adjust this value to control the movement speed.

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(KencingManager.instance.delayBeforeStart <= 0)
        {
            //Debug.Log("test");
            // Get input from the player
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate the movement vector
            Vector2 movement = new Vector2(horizontalInput, verticalInput);


            // Move the Rigidbody based on the input and speed multiplied by Time.deltaTime
            rb.velocity = new Vector2(movement.x * speed * Time.deltaTime, movement.y * speed * Time.deltaTime);
        }
    }
}
