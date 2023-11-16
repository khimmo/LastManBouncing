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
    public float moveForceDefault;
    public float jumpForce;
    public float maxSpeed;
    public float originalMaxSpeed;
    public float rayCastLength;
    public int maxJumps;
    public int jumpsRemaining;
    private bool isGrounded;
    public Rigidbody rb;
    public Transform playerCamera;
    public bool grounded;
    public float originalJumpForce;

    private string horizontalInput;
    private string verticalInput;
    private string jumpInput;
    private bool isBounceBoosted = false;
    private float currentTransitionTime = 0f;
    //private float totalTransitionDuration = 2f;

    private void Start()
    {
        originalMaxSpeed = maxSpeed;

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

    private void FixedUpdate()
    {
        

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
            //moveForce = 0f;
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

        if (isBounceBoosted)
        {
            // Check if the speed boost duration has elapsed
            if (Time.time >= bounceBoostEndTime)
            {
                isBounceBoosted = false;
                currentTransitionTime = 0f;
            }
        }

        if (currentTransitionTime < bounceBoostDuration)
        {
            currentTransitionTime += Time.deltaTime;
            maxSpeed = Mathf.Lerp(15f, originalMaxSpeed, currentTransitionTime / bounceBoostDuration);
        }

        rayCastLength = transform.localScale.x * 0.5f + 0.01f;
        //Ground Check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayCastLength);
        
        

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

    private void FixedUpdate()
    {

    }

    public void StartBounceBoostCoroutine()
    {
        if (!isBounceBoosted)
        {
            StartCoroutine(BounceBoostCoroutine());
        }
    }

    private float bounceBoostDuration = 0.5f;
    private float bounceBoostEndTime;

    private IEnumerator BounceBoostCoroutine()
    {
        isBounceBoosted = true;
        maxSpeed = 15f; // Increase maxSpeed
        bounceBoostEndTime = Time.time + bounceBoostDuration;

        // Wait for the speed boost duration to elapse
        yield return new WaitForSeconds(bounceBoostDuration);

        isBounceBoosted = false;
        currentTransitionTime = 0f;
    }

    public void StartSpeedBoostCoroutine(float speedMultiplier, float jumpForceBoost, float moveForceBoost, float speedBoostDuration)
    {
        StartCoroutine(SpeedBoostCoroutine(speedMultiplier, jumpForceBoost, moveForceBoost, speedBoostDuration));
    }

    private IEnumerator SpeedBoostCoroutine(float speedMultiplier, float jumpForceBoost, float moveForceBoost, float speedBoostDuration)
    {
        // Store the original values
        float originalMaxSpeed = maxSpeed;
        float originalJumpForce = jumpForce;
        float originalMoveForce = moveForce;

        // Apply the speed boost
        maxSpeed *= speedMultiplier;
        jumpForce *= jumpForceBoost;
        moveForce *= moveForceBoost;

        // Wait for the duration of the speed boost
        yield return new WaitForSeconds(speedBoostDuration);

        // Restore the original values
        maxSpeed = originalMaxSpeed;
        jumpForce = originalJumpForce;
        moveForce = originalMoveForce;
    }
}
