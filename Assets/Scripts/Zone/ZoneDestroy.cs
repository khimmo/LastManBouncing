using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDestroy : MonoBehaviour
{
    public ZoneShrink zoneShrink;

    void OnCollisionEnter(Collision other)
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
    }
}
