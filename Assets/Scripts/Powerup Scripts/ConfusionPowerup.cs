using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//private bool canApplyConfusion = false;

public class ConfusionPowerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply power-up effects to the player
            ApplyConfuser(other.GetComponent<BallCollision>());

            // Destroy the power-up object
            
            Destroy(gameObject);
        }
    }

    private void ApplyConfuser(BallCollision playerCollision)
    {
        if (playerCollision != null)
        {
            // Start the coroutine to invert controls for a duration
            //StartCoroutine(InvertControlsCoroutine(playerMovement));
            playerCollision.IsConfuser();
        }
    }

    
}