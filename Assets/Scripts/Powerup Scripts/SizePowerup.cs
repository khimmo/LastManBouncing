using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePowerup : MonoBehaviour
{
    public float massIncreasePercentage = 1.75f;
    public float radiusIncreasePercentage = 1.20f;
    public float jumpForceIncreasePercentage = 1.75f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply power-up effects to the ball
            BallPowerUp(other.GetComponent<Rigidbody>());
            
            Destroy(gameObject);
        }
    }

    private void BallPowerUp(Rigidbody ballRb)
    {
        // Increase the ball's mass
        ballRb.mass *= massIncreasePercentage;

        // Increase the ball's radius
        ballRb.transform.localScale *= radiusIncreasePercentage;

        NewBallMovementDP NewBallMovementDP = ballRb.GetComponent<NewBallMovementDP>();
        if (NewBallMovementDP != null)
        {
            NewBallMovementDP.jumpForce *= jumpForceIncreasePercentage;
            NewBallMovementDP.originalJumpForce *= jumpForceIncreasePercentage;
            NewBallMovementDP.moveForceDefault *= jumpForceIncreasePercentage;
        }
    }
}
