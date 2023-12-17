using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Spawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawn_Points = new List<Transform>();
    [SerializeField] List<GameObject> spawn_Objects = new List<GameObject>();
    [SerializeField] int powerUp_Count;
    [SerializeField] int randomPosition;
   
   
}
