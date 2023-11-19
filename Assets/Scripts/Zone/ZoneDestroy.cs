using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDestroy : MonoBehaviour
{
    public ZoneShrink zoneShrink;

    public float destroyTimer;

    /*void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Layer 1"))
        {
            Destroy(zoneShrink.zoneLayer1);
        }

        if (other.gameObject.CompareTag("Layer 2"))
        {
            Destroy(zoneShrink.zoneLayer2);
        }

        if (other.gameObject.CompareTag("Layer 3"))
        {
            Destroy(zoneShrink.zoneLayer3);
        } 
        
        if (other.gameObject.CompareTag("Layer 4"))
        {
            Destroy(zoneShrink.zoneLayer4);
        }

        if (other.gameObject.CompareTag("Layer 5"))
        {
            Destroy(zoneShrink.zoneLayer5);
        }

        if (other.gameObject.CompareTag("Layer 6"))
        {
            Destroy(zoneShrink.zoneLayer6);
        }

        if (other.gameObject.CompareTag("Layer 7"))
        {
            Destroy(zoneShrink.zoneLayer7);
        }
    }*/

    public void DestroyTimer()
    {
        destroyTimer += Time.deltaTime;
    }
}
