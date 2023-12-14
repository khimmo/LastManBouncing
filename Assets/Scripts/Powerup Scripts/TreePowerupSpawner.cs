using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePowerupSpawner : MonoBehaviour
{

    public float spawnHeight;
    public GameObject sizePowerupPrefab;
    public GameObject speedPowerupPrefab;
    public GameObject confusionPowerupPrefab;
    public GameObject shockwavePowerupPrefab;

    Audioplayer audioplayer;

    private void Start()
    {
        audioplayer = FindObjectOfType<Audioplayer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        NewBallMovementDP playerMovement = other.GetComponent<NewBallMovementDP>();

        if (other.CompareTag("Player"))
        {
            
            Destroy(gameObject);
            audioplayer.Tree_Falling();
            DropPowerup();
            // && rb.velocity.magnitude > (0 * playerMovement.originalMaxSpeed)
        }
    }

    private void DropPowerup()
    {
        int randomNumber = Random.Range(1, 6);

        if (randomNumber == 5)
        {
            InstantiatePowerup();
        }
        
        
    }

    private void InstantiatePowerup()
    {
        int randomNumber = Random.Range(1, 5);
        Vector3 spawnPosition = transform.position + Vector3.up * spawnHeight;

        // Instantiate the corresponding powerup based on the random number
        switch (randomNumber)
        {
            case 1:
                Instantiate(sizePowerupPrefab, spawnPosition, Quaternion.identity);
                break;
            case 2:
                Instantiate(speedPowerupPrefab, spawnPosition, Quaternion.identity);
                break;
            case 3:
                Instantiate(confusionPowerupPrefab, spawnPosition, Quaternion.identity);
                break;
            case 4:
                Instantiate(shockwavePowerupPrefab, spawnPosition, Quaternion.identity);
                break;
            default:
                Debug.LogError("Invalid # for powerup instantiation.");
                break;
        }
    }
}
