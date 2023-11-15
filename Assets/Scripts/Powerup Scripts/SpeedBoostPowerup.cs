using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerup : MonoBehaviour
{
    public float speedBoostMultiplier = 1.5f;
    public float jumpForceBoost = 1.25f;
    public float moveForceBoost = 1.25f;
    public float speedBoostDuration = 15.0f; // Adjust the duration as needed

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply speed boost effects to the player
            ApplySpeedBoost(other.GetComponent<NewBallMovementDP>());
            // Destroy the power-up GameObject
            Destroy(gameObject);
        }
    }

    private void ApplySpeedBoost(NewBallMovementDP NewBallMovementDP)
    {
        // Check if the script is attached to the player
        if (NewBallMovementDP != null)
        {
            // Start the coroutine to apply temporary speed boost
            NewBallMovementDP.StartSpeedBoostCoroutine(speedBoostMultiplier, jumpForceBoost, moveForceBoost, speedBoostDuration);
        }
    }
}
