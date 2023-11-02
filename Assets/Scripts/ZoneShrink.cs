using System.Collections;
using System.Linq;
using UnityEngine;

public class ZoneShrink : MonoBehaviour
{
    [SerializeField] private Rigidbody layer1rb;
    [SerializeField] private Rigidbody layer2rb;
    [SerializeField] private Rigidbody layer3rb;

    [SerializeField] private GameObject zoneLayer1;
    [SerializeField] private GameObject zoneLayer2;
    [SerializeField] private GameObject zoneLayer3;

    [SerializeField] private float timer ;

    [SerializeField] private int zoneIndex = 0;

    void Timer()
    {
        timer += Time.deltaTime;
        Mathf.Round(timer);
    }

    void ShrinkZone()
    {
        if(timer >= 5 && zoneIndex == 0)
        {
            Layer1Drop();
            timer = 0;
            zoneIndex++;
        }

        if (timer >= 5 && zoneIndex == 1)
        {
            Layer2Drop();
            timer = 0;
            zoneIndex++;
        }

        if (timer >= 5 && zoneIndex == 2)
        {
            Layer3Drop();
            timer = 0;
            zoneIndex++;
        }
    }

    void Layer1Drop()
    {
        layer1rb.constraints = RigidbodyConstraints.None;
    }
    
    void Layer2Drop()
    {
        layer2rb.constraints = RigidbodyConstraints.None;
    } 
    
    void Layer3Drop()
    {
        layer3rb.constraints = RigidbodyConstraints.None;
    }

    void Update()
    {
        ShrinkZone();
        Timer();
    }
}
