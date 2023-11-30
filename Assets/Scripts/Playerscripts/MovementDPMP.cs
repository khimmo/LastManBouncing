using UnityEngine;

public class MovementDPMP : MonoBehaviour
{
    public enum PlayerNumber
    {
        Player1,
        Player2,
        Player3,
        Player4
    }

    public PlayerNumber playerNumber;

    public float moveForce;
    public float moveForceDefault;
    public float jumpForce;
    public float jumpForceDefault;
    public float maxSpeed;
    public float originalMaxSpeed;
    public float rayCastLength;
    public int maxJumps;
    public int jumpsRemaining;
    private bool isGrounded;
    public Rigidbody rb;
    public bool grounded;
    public float originalJumpForce;
    private string horizontalInput;
    private string verticalInput;
    private string jumpInput;

    private void Start()
    {
        originalMaxSpeed = maxSpeed;
        jumpForce = jumpForceDefault;

        rb = GetComponent<Rigidbody>();

        
        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                horizontalInput = "Horizontal_P1";
                verticalInput = "Vertical_P1";
                jumpInput = "Jump_P1";
                break;
            case PlayerNumber.Player2:
                horizontalInput = "Horizontal_P2";
                verticalInput = "Vertical_P2";
                jumpInput = "Jump_P2";
                break;
            case PlayerNumber.Player3:
                horizontalInput = "Horizontal_P3";
                verticalInput = "Vertical_P3";
                jumpInput = "Jump_P3";
                break;
            case PlayerNumber.Player4:
                horizontalInput = "Horizontal_P4";
                verticalInput = "Vertical_P4";
                jumpInput = "Jump_P4";
                break;
        }
    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis(horizontalInput);
        float moveHorizontal = Input.GetAxis(verticalInput);

        // Basic movement logic
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if (movement.magnitude > 0.1f)
        {
            rb.AddForce(movement * moveForce, ForceMode.Impulse);
        }

        // Limit the maximum speed
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }
        else
        {
            moveForce = moveForceDefault;
        }
    }

    private void Update()
    {
        // Reset jump force if needed
        if (jumpForce < jumpForceDefault)
        {
            jumpForce = jumpForceDefault;
        }

        // Ground check
        rayCastLength = transform.localScale.x * 0.5f + 0.01f;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayCastLength);

        // Handle jumping
        if (Input.GetButtonDown(jumpInput) && jumpsRemaining > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsRemaining--;
        }

        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
