using System.Collections;
using System.Linq;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZoneShrink : MonoBehaviour
{
    [SerializeField] private Rigidbody layer1rb;
    [SerializeField] private Rigidbody layer2rb;
    [SerializeField] private Rigidbody layer3rb;
    [SerializeField] private Rigidbody layer4rb;
    [SerializeField] private Rigidbody layer5rb;
    [SerializeField] private Rigidbody layer6rb;
    [SerializeField] private Rigidbody layer7rb;

    [SerializeField] public GameObject zoneLayer1;
    [SerializeField] public GameObject zoneLayer2;
    [SerializeField] public GameObject zoneLayer3;
    [SerializeField] public GameObject zoneLayer4;
    [SerializeField] public GameObject zoneLayer5;
    [SerializeField] public GameObject zoneLayer6;
    [SerializeField] public GameObject zoneLayer7;

    [SerializeField] private float timer = 25f;

    [SerializeField] private int zoneIndex = 0;

    [SerializeField] private TextMeshProUGUI timerText;
 
    void Timer()
    {
        timer -= Time.deltaTime;
        timerText.text = string.Format("Time until zone shrink: " + Mathf.Round(timer));
    }

    void ShrinkZone()
    {
        if (timer <= 0 && zoneIndex == 0)
        {
            StartCoroutine(Layer1Drop());
            timer = 25 ;
            zoneIndex++;
        }

        if (timer <= 0 && zoneIndex == 1)
        {
            StartCoroutine(Layer2Drop());
            timer = 25;
            zoneIndex++;
        }

        if (timer <= 0 && zoneIndex == 2)
        {
            StartCoroutine(Layer3Drop());
            timer = 25;
            zoneIndex++;
        }

        if (timer <= 0 && zoneIndex == 3)
        {
            StartCoroutine(layer4Drop());
            timer = 25;
            zoneIndex++;
        }

        if (timer <= 0 && zoneIndex == 4)
        {
            StartCoroutine(Layer5Drop());
            timer = 25;
            zoneIndex++;
        }

        if (timer <= 0 && zoneIndex == 5)
        {
            StartCoroutine(Layer6Drop());
            timer = 25;
            zoneIndex++;
        }

        if(timer <= 0 && zoneIndex == 6)
        {
            StartCoroutine(Layer7drop());
            timer = 25;
            zoneIndex++;
        }
    }

    IEnumerator Layer1Drop()
    {
        layer1rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3);
        Destroy(zoneLayer1);
    }

    IEnumerator Layer2Drop()
    {
        layer2rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3);
        Destroy(zoneLayer2);
    }

    IEnumerator Layer3Drop()
    {
        layer3rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3);
        Destroy(zoneLayer3);
    }

    IEnumerator layer4Drop()
    {
        layer4rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3);
        Destroy(zoneLayer4);
    }

    IEnumerator Layer5Drop()
    {
        layer5rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3);
        Destroy(zoneLayer5);
    }

    IEnumerator Layer6Drop()
    {
        layer6rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3);
        Destroy(zoneLayer6);
    }

    IEnumerator Layer7drop()
    {
        layer7rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3);
        Destroy(zoneLayer7);
    }

    void Update()
    {
        Timer();
        ShrinkZone();
    }
}
