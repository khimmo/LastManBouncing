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
    public float jumpForceDefault;
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
    private string shockwaveInput;
    private bool isBounceBoosted = false;
    public bool isShockBoosted = false;
    public bool controlsInverted;
    private float currentBounceTransitionTime = 0f;
    private float currentShockTransitionTime = 0f;
    public float shockwaveForce;
    public float shockwaveRadius;
    public bool hasShockwave = false;
    public GameObject shockwaveExplosionPrefab;
    //private float totalTransitionDuration = 2f;

    private void Start()
    {
        originalMaxSpeed = maxSpeed;
        jumpForce = jumpForceDefault;

        rb = GetComponent<Rigidbody>();

        if (playerNumber == PlayerNumber.Player1)
        {
            horizontalInput = "Horizontal";
            verticalInput = "Vertical";
            jumpInput = "Jump_P1";
            shockwaveInput = "Shockwave_P1";
        }
        else if (playerNumber == PlayerNumber.Player2)
        {
            horizontalInput = "Horizontal_P2";
            verticalInput = "Vertical_P2";
            jumpInput = "Jump_P2";
            shockwaveInput = "Shockwave_P2";
        }
    }

    public void InvertControls()
    {
        controlsInverted = true;
    }

    public void RevertControls()
    {
        controlsInverted = false;
    }

    private void FixedUpdate()
    {


        

        float moveVertical = Input.GetAxis(horizontalInput);
        float moveHorizontal = Input.GetAxis(verticalInput);

        if (controlsInverted == true)
        {
            // Invert movement inputs
            moveVertical = -moveVertical;
            moveHorizontal = -moveHorizontal;
        }



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
        if (jumpForce < jumpForceDefault)
        {
            jumpForce = jumpForceDefault;
        }

        

        if (isBounceBoosted)
        {
            // Check if the speed boost duration has elapsed
            if (Time.time >= bounceBoostEndTime)
            {
                isBounceBoosted = false;
                currentBounceTransitionTime = 0f;
            }
        }

        if (currentBounceTransitionTime < bounceBoostDuration)
        {
            currentBounceTransitionTime += Time.deltaTime;
            maxSpeed = Mathf.Lerp(15f, originalMaxSpeed, currentBounceTransitionTime / bounceBoostDuration);
        }

        if (currentShockTransitionTime < shockBoostDuration)
        {
            currentShockTransitionTime += Time.deltaTime;
            maxSpeed = Mathf.Lerp(20f, originalMaxSpeed, currentShockTransitionTime / shockBoostDuration);
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

        if (Input.GetButtonDown(shockwaveInput) && hasShockwave == true)
        {
            TriggerShockwave();
        }


    }

    public void StartBounceBoostCoroutine()
    {
        if (!isBounceBoosted)
        {
            StartCoroutine(BounceBoostCoroutine());
        }
    }

    public void StartShockBoostCoroutine()
    {
        if (!isShockBoosted)
        {
            StartCoroutine(ShockBoostCoroutine());
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
        currentBounceTransitionTime = 0f;
    }

    private float shockBoostDuration = 0.75f;
    private float shockBoostEndTime;

    private IEnumerator ShockBoostCoroutine()
    {
        isShockBoosted = true;
        maxSpeed = 20f; // Increase maxSpeed
        shockBoostEndTime = Time.time + shockBoostDuration;

        // Wait for the speed boost duration to elapse
        yield return new WaitForSeconds(shockBoostDuration);

        isShockBoosted = false;
        currentShockTransitionTime = 0f;
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

    public void StartInvertControlsCoroutine()
    {
        StartCoroutine(InvertControlsCoroutine());
    }

    private IEnumerator InvertControlsCoroutine()
    {
        // Invert the controls
        InvertControls();

        // Wait for a specified duration
        yield return new WaitForSeconds(7f);

        // Revert the controls after the duration
        RevertControls();
    }

    void TriggerShockwave()
    {
        // Find all nearby players within a radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, shockwaveRadius);
        hasShockwave = false;

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Apply a force to each player
                Rigidbody playerRb = collider.GetComponent<Rigidbody>();
                NewBallMovementDP playerMovement = collider.GetComponent<NewBallMovementDP>();
                if (playerRb != null)
                {
                    ApplyShockwaveForce(playerRb);
                    //playerMovement.IsShockBoosted();
                    playerMovement.StartShockBoostCoroutine();
                    
                }
            }
        }
    }

    void ApplyShockwaveForce(Rigidbody rb)
    {
        
        // Calculate the direction from the shockwave center to the player
        Vector3 direction = rb.position - transform.position;

        // Apply a force in the calculated direction
        rb.AddForce(direction.normalized * shockwaveForce, ForceMode.Impulse);

        InstantiateShockwaveExplosion(transform.position);
    }

    void InstantiateShockwaveExplosion(Vector3 position)
    { 
        
        GameObject particles = Instantiate(shockwaveExplosionPrefab, position, Quaternion.identity);


    }

    public void HasShockwave()
    {
        hasShockwave = true;
    }

    
}
