using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwavePowerup : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply power-up effects to the player
            NewBallMovementDP playerMovement = other.GetComponent<NewBallMovementDP>();
            playerMovement.HasShockwave();

            // Destroy the power-up object

            Destroy(gameObject);
        }
    }

}