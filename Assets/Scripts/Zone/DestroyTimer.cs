using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float destroyTimer;

    public void ZoneDestroyTimer()
    {
        destroyTimer += Time.deltaTime;
    }

    void Update()
    {
        ZoneDestroyTimer();
    }
}
