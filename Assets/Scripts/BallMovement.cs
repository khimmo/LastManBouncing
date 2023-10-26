using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveForce;   // The force to apply when moving the ball
    public float jumpForce;    // The force to apply when jumping
    public float maxSpeed;    // The maximum speed of the ball
    public float maxHeight;   // The maximum allowed height for the ball
    public int maxJumps;        // Maximum number of jumps (including initial jump)
    private int jumpsRemaining;      // Number of jumps remaining
    private bool isGrounded;         // A flag to check if the ball is grounded
    public Rigidbody rb;            // The Rigidbody component of the ball
    public Transform playerCamera; // Reference to the camera transform

    //public BallHealth ballHealth;
    //public Text tutorialText;

    private void Start()
    {
        // Get the Rigidbody component of the ball
        rb = GetComponent<Rigidbody>();
        //tutorialText.gameObject.SetActive(true);
    }

    private void Update()
    {
        // Check if the ball is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.4f);
        
        // Read input for movement
        float moveVertical = Input.GetAxis("Horizontal");
        float moveHorizontal = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 cameraForward = playerCamera.forward;
        Vector3 cameraRight = playerCamera.right;
        cameraForward.y = 0f; // Ignore vertical camera rotation
        cameraRight.y = 0f;
        Vector3 movement = cameraForward.normalized * moveHorizontal + cameraRight.normalized * moveVertical;


        // Apply impulses based on input
        if (movement.magnitude > 0.1f)
        {
            //movement.z *= 2;
            // Apply the force as an impulse to the Rigidbody
            rb.AddForce(movement * moveForce, ForceMode.Impulse);
            //tutorialText.gameObject.SetActive(false);

        }

        // Limit the maximum speed of the ball
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }

        // Jump mechanic
        if (isGrounded)
        {
            // If the ball is grounded, reset the number of jumps
            jumpsRemaining = maxJumps;
        }

        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            // Perform a jump if there are jumps remaining
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsRemaining--;

            
        }


    }
}
