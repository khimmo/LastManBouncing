using System.Collections;
using System.Linq;
using UnityEngine;

public class ZoneShrink : MonoBehaviour
{
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
        if(timer >= 40 && zoneIndex == 0)
        {
            zoneLayer1.SetActive(false);
            timer = 0;
            zoneIndex++;
        }

        if (timer >= 40 && zoneIndex == 1)
        {
            zoneLayer2.SetActive(false);
            timer = 0;
            zoneIndex++;
        }

        if (timer >= 40 && zoneIndex == 2)
        {
            zoneLayer3.SetActive(false);
            timer = 0;
            zoneIndex++;
        }
    }

    void Update()
    {
        ShrinkZone();
        Timer();
    }
}
