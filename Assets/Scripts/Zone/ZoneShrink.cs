using System.Collections;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;

public class ZoneShrink : MonoBehaviour
{
    [SerializeField] private Rigidbody layer1rb;
    [SerializeField] private Rigidbody layer2rb;
    [SerializeField] private Rigidbody layer3rb;
    [SerializeField] private Rigidbody layer4rb;
    [SerializeField] private Rigidbody layer5rb;
    [SerializeField] private Rigidbody layer6rb;

    [SerializeField] public GameObject zoneLayer1;
    [SerializeField] public GameObject zoneLayer2;
    [SerializeField] public GameObject zoneLayer3;
    [SerializeField] public GameObject zoneLayer4;
    [SerializeField] public GameObject zoneLayer5;
    [SerializeField] public GameObject zoneLayer6;

    [SerializeField] private float timer ;

    [SerializeField] private int zoneIndex = 0;

    void Timer()
    {
        timer += Time.deltaTime;
        Mathf.Round(timer);
    }

    void ShrinkZone()
    {
        if (timer >= 5 && zoneIndex == 0)
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

        if (timer >= 5 && zoneIndex == 3)
        {
            layer4Drop();
            timer = 0;
            zoneIndex++;

        }

        if (timer >= 5 && zoneIndex == 4)
        {
            Layer5Drop();
            timer = 0;
            zoneIndex++;
        }

        if (timer >= 5 && zoneIndex == 5)
        {
            Layer6Drop();
            timer = 0;
            zoneIndex++;
        }

    }
    void Layer1Drop()
    {
        layer1rb.constraints = RigidbodyConstraints.None;
        //transform.Translate(Vector3.down * Time.deltaTime);
    }
    
    void Layer2Drop()
    {
        layer2rb.constraints = RigidbodyConstraints.None;
    } 
    
    void Layer3Drop()
    {
        layer3rb.constraints = RigidbodyConstraints.None;
    }

    void layer4Drop()
    {
        layer4rb.constraints = RigidbodyConstraints.None;
    }

    void Layer5Drop()
    {
        layer5rb.constraints = RigidbodyConstraints.None;
    }

    void Layer6Drop()
    {
        layer6rb.constraints = RigidbodyConstraints.None;
    }
        

    void Update()
    {
        ShrinkZone();
        Timer();
    }
}
