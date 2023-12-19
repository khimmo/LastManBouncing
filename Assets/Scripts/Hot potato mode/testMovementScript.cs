using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;



public class testMovementScript : MonoBehaviour
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
    public Transform playerCamera;
    public bool grounded;
    public bool landCheck;
    //public bool groundedState;
    public float originalJumpForce;
    private string horizontalInput;
    private string verticalInput;
    private string jumpInput;
    private string shockwaveInput;
    private bool isBounceBoosted = false;
    public bool isShockBoosted = false;
    public bool isSpeedBoosted = false;
    public bool controlsInverted;
    private float currentBounceTransitionTime = 0f;
    private float currentShockTransitionTime = 0f;
    public float shockwaveForce;
    public float shockwaveRadius;
    public bool hasShockwave = false;
    public GameObject shockwaveExplosionPrefab;
    public float burgerCount;
    public float verticalVelocity;
    public float vibrateIntensity;
    public bool isPowerUp;
    public bool istagged;

    public Material invertedControlsMaterial; // Assign the material with inverted controls texture in the Inspector
    private Material originalMaterial;
    private Renderer ballRenderer;

    Audioplayer audioplayer;
    //EtherealPowerup ethereal;
    //private float totalTransitionDuration = 2f;

    private void Start()
    {
        originalMaxSpeed = maxSpeed;
        jumpForce = jumpForceDefault;
        landCheck = true;


        rb = GetComponent<Rigidbody>();

        ballRenderer = GetComponent<Renderer>();
        originalMaterial = ballRenderer.material;
        audioplayer = FindObjectOfType<Audioplayer>();
        //ethereal = GetComponent<EtherealPowerup>();

        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                horizontalInput = "Horizontal_P1";
                verticalInput = "Vertical_P1";
                jumpInput = "Jump_P1";
                shockwaveInput = "Shockwave_P1";
                break;
            case PlayerNumber.Player2:
                horizontalInput = "Horizontal_P2";
                verticalInput = "Vertical_P2";
                jumpInput = "Jump_P2";
                shockwaveInput = "Shockwave_P2";
                break;
            case PlayerNumber.Player3:
                horizontalInput = "Horizontal_P3";
                verticalInput = "Vertical_P3";
                jumpInput = "Jump_P3";
                shockwaveInput = "Shockwave_P3";
                break;
            case PlayerNumber.Player4:
                horizontalInput = "Horizontal_P4";
                verticalInput = "Vertical_P4";
                jumpInput = "Jump_P4";
                shockwaveInput = "Shockwave_P4";
                break;
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

        burgerCount = Mathf.Round(Mathf.Log(rb.mass, 1.75f));


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

        verticalVelocity = Mathf.Abs(rb.velocity.y);





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
            audioplayer.Jump_audio();
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

    /* void OnCollisionEnter(Collision collision)
    {
        //Linearly scales vibration intensity on landing at speeds between 15 (0%) and 30 (100%).

        if (collision.gameObject.CompareTag("GROUND") && verticalVelocity > 20f && verticalVelocity < 30f && landCheck == true)
        {

            vibrateIntensity = (Mathf.Abs(verticalVelocity) - 15) / 15;
            

        }
        //Any landing speed above 30 will not further increase vibration intensity.

        else if (collision.gameObject.CompareTag("GROUND") && Mathf.Abs(verticalVelocity) > 30f && landCheck == true)
        {
            vibrateIntensity = 1;
            
        }

        else
        {
            vibrateIntensity = 0;
            return;
        }

        Vibrate();

        //This coroutine is done so that the OnCollisionEnter function doesn't return multiple vibrate values at once. It functions as a small artificial cooldown before it can be called again by manipulating the landCheck bool.

        StartCoroutine(AllowLandingCheck());
        landCheck = false;


    } 

    void Vibrate()
    {
        Debug.Log("Controller vibrate at " + vibrateIntensity * 100 + "%");
    }

    IEnumerator AllowLandingCheck()
    {
        yield return new WaitForSeconds(0.2f);
        landCheck = true;
    } */


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            float verticalVelocity = collision.relativeVelocity.y;
            float vibrateIntensity = 0f;

            if (Mathf.Abs(verticalVelocity) > 20f && Mathf.Abs(verticalVelocity) < 30f)
            {
                vibrateIntensity = (Mathf.Abs(verticalVelocity) - 15) / 15;
                Debug.Log("Controller vibrate at " + vibrateIntensity * 100 + "%");
            }
            else if (Mathf.Abs(verticalVelocity) > 30f)
            {
                vibrateIntensity = 1;
                Debug.Log("Controller vibrate at 100%");
            }

            //if (vibrateIntensity > 0)
            //{
            //VibrateController(vibrateIntensity);
            //}
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<testMovementScript>().isPowerUp == true)
            {
                Debug.Log(collision.gameObject);
                StartCoroutine(SlowDown_Active());
            }
        }
    }

    //private void VibrateController(float intensity)
    // {

    // var gamepad = Gamepad.current;
    //if (gamepad != null)
    //{
    // gamepad.SetMotorSpeeds(intensity, intensity); // Left and right motor speeds
    //Invoke("StopVibration", 0.5f); // Adjust duration as needed
    //}
    //}

    //private void StopVibration()
    //{
    // var gamepad = Gamepad.current;
    //if (gamepad != null)
    // {
    //gamepad.SetMotorSpeeds(0, 0);
    //}
    // }

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

    private float bounceBoostDuration = 0.75f;
    private float bounceBoostEndTime;

    private IEnumerator BounceBoostCoroutine()
    {
        isBounceBoosted = true;
        maxSpeed = 20f; // Increase maxSpeed
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
        maxSpeed = 30f; // Increase maxSpeed
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
        isSpeedBoosted = true;


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
        isSpeedBoosted = false;
    }

    public void StartInvertControlsCoroutine()
    {
        StartCoroutine(InvertControlsCoroutine());
        ballRenderer.material = invertedControlsMaterial;
    }

    private IEnumerator InvertControlsCoroutine()
    {

        InvertControls();


        yield return new WaitForSeconds(7f);


        RevertControls();
        ballRenderer.material = originalMaterial;
    }

    void TriggerShockwave()
    {
        // Find all nearby players within a radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, shockwaveRadius);
        hasShockwave = false;
        audioplayer.Explosion();

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {

                Rigidbody playerRb = collider.GetComponent<Rigidbody>();
                PlayerPowerupManager powerup = collider.GetComponent<PlayerPowerupManager>();

                NewBallMovementDP playerMovement = collider.GetComponent<NewBallMovementDP>();
                if (playerRb != null && powerup.isEtherealActive == false)
                {
                    ApplyShockwaveForce(playerRb);

                    playerMovement.StartShockBoostCoroutine();

                }
            }
        }
    }

    void ApplyShockwaveForce(Rigidbody rb)
    {

        // Calculate the direction from the shockwave center to the player
        Vector3 direction = rb.position - transform.position;


        rb.AddForce(direction.normalized * shockwaveForce * rb.mass, ForceMode.Impulse);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("slowdownpowerup"))
        {
            isPowerUp = true;
            Destroy(other.gameObject);
        }
    }


    IEnumerator SlowDown_Active()
    {
        Debug.Log("slow down");
        // isPowerUp = false;
        float temp = originalMaxSpeed;
        originalMaxSpeed = originalMaxSpeed / 2;
        yield return new WaitForSeconds(10);
        originalMaxSpeed = temp;
        maxSpeed = originalMaxSpeed;

    }

    private void OnCollisionExit(Collision other)
    {
        // comparing player tag with game object and making ispowerUp  bool false.
        if (other.gameObject.CompareTag("Player"))
        {
            isPowerUp = false;
            //making istagged true and calling the delay function using coroutine.
            if (other.gameObject.GetComponent<testMovementScript>().istagged == true)
            {
                Debug.Log(other.gameObject);
                other.gameObject.GetComponent<testMovementScript>().istagged = false;
                StartCoroutine(Delay());
            }
        } 
    }
     // waiting for ).3 seconds before making IsTagged bool back to true.
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        istagged = true;
    }

    

}