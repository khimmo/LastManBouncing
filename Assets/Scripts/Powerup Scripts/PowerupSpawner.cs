using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour

{
    public GameObject[] powerupPrefabs; // Array of powerup prefabs to spawn
    public float spawnRadius = 30f;     // Radius within which powerups will spawn
    public float spawnInterval = 7.5f;  // Time interval between spawns

    public float spawnHeight;
    public GameObject sizePowerupPrefab;
    public GameObject speedPowerupPrefab;
    public GameObject confusionPowerupPrefab;
    public GameObject shockwavePowerupPrefab;
    public GameObject etherealPowerupPrefab;

    public void beginSpawning()
    {
        // Start spawning coroutine
        StartCoroutine(SpawnPowerups());
        Debug.Log("Beginning Spawning");
    }

    IEnumerator SpawnPowerups()
    {
        while (true)
        {
            
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomPosition.x, spawnHeight, randomPosition.y) + transform.position;

            
            int randomNumber = Random.Range(1, 6);
            

            
            switch (randomNumber)
            {
                case 1:
                    Instantiate(sizePowerupPrefab, spawnPosition, Quaternion.identity);
                    Debug.Log("Spawned " + randomNumber);
                    break;
                case 2:
                    Instantiate(speedPowerupPrefab, spawnPosition, Quaternion.identity);
                    Debug.Log("Spawned " + randomNumber);
                    break;
                case 3:
                    Instantiate(confusionPowerupPrefab, spawnPosition, Quaternion.identity);
                    Debug.Log("Spawned " + randomNumber);
                    break;
                case 4:
                    Instantiate(shockwavePowerupPrefab, spawnPosition, Quaternion.identity);
                    Debug.Log("Spawned " + randomNumber);
                    break;
                case 5:
                    Instantiate(etherealPowerupPrefab, spawnPosition, Quaternion.identity);
                    Debug.Log("Spawned " + randomNumber);
                    break;

                default:
                    Debug.Log("Invalid # for powerup instantiation.");
                    break;
            }

            // Wait for the next spawnInterval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
