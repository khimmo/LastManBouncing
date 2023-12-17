using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Spawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawn_Points = new List<Transform>();
    [SerializeField] List<GameObject> powerUps = new List<GameObject>();
    [SerializeField] int powerUp_Count;
    [SerializeField] int randomPosition;
    [SerializeField] List<GameObject> spawnned_PowerUp = new List<GameObject>();
    private bool IsSpawnning = true;
    Transform spawnPosition;

    void Spawn_PowerUp()
    {
        // Debug.Log("spawanned");
        spawn_Points.RemoveAll(IsObjectMissing);
        for (int i = 0; i < powerUp_Count; i++)
        {
            RandomPosition();
            int randomPowerUp = Random.Range(0, powerUps.Count);
            GameObject spawnPowerUp = Instantiate(powerUps[randomPowerUp], spawnPosition.position, Quaternion.identity);
            spawnned_PowerUp.Add(spawnPowerUp);
            powerUp_Count = powerUp_Count - 1;
            IsSpawnning = false;
        }

        if (!IsSpawnning)
        {
            StartCoroutine(DeleteObject());
        }


    }

    IEnumerator DeleteObject()
    {
        IsSpawnning = true;
        yield return new WaitForSeconds(10f);
        foreach (var item  in spawnned_PowerUp)
        {
            Destroy(item.gameObject);
        } 
        powerUp_Count = 5;
        spawnned_PowerUp.Clear();
    }

    void RandomPosition()
    {
        randomPosition = Random.Range(0, spawn_Points.Count);
        spawnPosition= spawn_Points[randomPosition];
    }


    private void LateUpdate()
    {
        Spawn_PowerUp();
    }

    bool IsObjectMissing(Transform obj)
    {
        return obj == null;
    }


}
