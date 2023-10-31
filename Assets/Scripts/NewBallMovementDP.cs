using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallMovementDP : MonoBehaviour
{
    public enum PlayerNumber
    {
        Player1,
        Player2
    }

    public PlayerNumber playerNumber;  

    public float moveForce;
    public float jumpForce;
    public float maxSpeed;
    public float maxHeight;
    public int maxJumps;
    private int jumpsRemaining;
    private bool isGrounded;
    public Rigidbody rb;
    public Transform playerCamera;

    private string horizontalInput;
    private string verticalInput;
    private string jumpInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (playerNumber == PlayerNumber.Player1)
        {
            horizontalInput = "Horizontal";
            verticalInput = "Vertical";
            jumpInput = "Jump";
        }
        else if (playerNumber == PlayerNumber.Player2)
        {
            horizontalInput = "Horizontal_P2";
            verticalInput = "Vertical_P2";
            jumpInput = "Jump_P2";
        }
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.4f);

        float moveVertical = Input.GetAxis(horizontalInput);
        float moveHorizontal = Input.GetAxis(verticalInput);

        Vector3 cameraForward = playerCamera.forward;
        Vector3 cameraRight = playerCamera.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        Vector3 movement = cameraForward.normalized * moveHorizontal + cameraRight.normalized * moveVertical;

        if (movement.magnitude > 0.1f)
        {
            rb.AddForce(movement * moveForce, ForceMode.Impulse);
        }

        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }

        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
        }

        if (Input.GetButtonDown(jumpInput) && jumpsRemaining > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsRemaining--;
        }
    }
}
