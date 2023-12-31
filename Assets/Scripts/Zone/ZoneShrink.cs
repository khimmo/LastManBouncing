using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] Transform lastZone;

    [SerializeField] List<GameObject> layer1Assets = new List<GameObject>();
    [SerializeField] List<GameObject> layer2Assets = new List<GameObject>();
    [SerializeField] List<GameObject> layer3Assets = new List<GameObject>();
    [SerializeField] List<GameObject> layer4Assets = new List<GameObject>();
    [SerializeField] List<GameObject> layer5Assets = new List<GameObject>();
    [SerializeField] GameObject layer6PowerUp;
    [SerializeField] GameObject layer5PowerUp;
    [SerializeField] GameObject layer4PowerUp;
    [SerializeField] GameObject layer3PowerUp;
    [SerializeField] GameObject layer2PowerUp;
    [SerializeField] GameObject layer1PowerUp;

    // main timer variable
    [SerializeField] public float timer = 25f;
    public float shrinkSpeed = 0.5f;

    // timer reset variable
    public float timerDefault = 25f;

    // destroy zone timer.( used in co routine)
    public float zoneDestroyTimer = 3f;
    public bool isLastZone= false;

    
    [SerializeField] public int zoneIndex = 0;
    [SerializeField] private TextMeshProUGUI timerText;

    public PowerupSpawner spawner;

    Audioplayer audioplayer;

    void Start()
    {
        spawner = GetComponent<PowerupSpawner>();
        audioplayer = FindObjectOfType<Audioplayer>();
    }

    void Timer()
    {
        timer -= Time.deltaTime;
        if (zoneIndex < 7)
        {
            timerText.text = string.Format("Zone collapses in: " + Mathf.Round(timer) + "!");
        }
        else {
            timerText.text = string.Format("");
             }
            
    }

    void ShrinkZone()
    {
        

        if (timer <= 0 && zoneIndex == 0)
        {
            
            StartCoroutine(Layer1Drop());
            Destroy(layer6PowerUp);
            //audioplayer.Zone_Shrink();
            timer = timerDefault;
            zoneIndex++;
            
            
        }

        if (timer <= 0 && zoneIndex == 1)
        {
            StartCoroutine(Layer2Drop());
            Destroy(layer5PowerUp);
            //audioplayer.Zone_Shrink();
            timer = timerDefault;
            zoneIndex++;
        }

        if (timer <= 0 && zoneIndex == 2)
        {
            StartCoroutine(Layer3Drop());
            Destroy(layer5PowerUp);
            //audioplayer.Zone_Shrink();
            timer = timerDefault;
            zoneIndex++;
        }

        if (timer <= 0 && zoneIndex == 3)
        {
            StartCoroutine(layer4Drop());
            Destroy(layer4PowerUp);
            //audioplayer.Zone_Shrink();
            timer = timerDefault;
            zoneIndex++;
        }

        if (timer <= 0 && zoneIndex == 4)
        {
            StartCoroutine(Layer5Drop());
            Destroy(layer3PowerUp);
            //audioplayer.Zone_Shrink();
            timer = timerDefault;
            zoneIndex++;
        }

        if (timer <= 0 && zoneIndex == 5)
        {
            StartCoroutine(Layer6Drop());
            Destroy(layer2PowerUp);
            //audioplayer.Zone_Shrink();
            timer = timerDefault;
            zoneIndex++;
        }

        if(timer <= 0 && zoneIndex == 6)
        {
            StartCoroutine(Layer7drop());
            Destroy(layer1PowerUp);
            //audioplayer.Zone_Shrink();
            timer = timerDefault;
            zoneIndex++;
            spawner.beginSpawning();

        }
    }

    IEnumerator Layer1Drop()
    {
        layer1rb.useGravity = true;
        layer1rb.isKinematic = false;
        foreach(var item in layer1Assets)
        {
            item.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(zoneDestroyTimer);
        Destroy(zoneLayer1);
        
        
    }

    IEnumerator Layer2Drop()
    {
        layer2rb.useGravity = true;
        layer2rb.isKinematic = false;
        foreach (var item in layer2Assets)
        {
            item.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(zoneDestroyTimer);
        Destroy(zoneLayer2);
    }

    IEnumerator Layer3Drop()
    {
        layer3rb.useGravity = true;
        layer3rb.isKinematic = false;
        foreach (var item in layer3Assets)
        {
            item.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(zoneDestroyTimer);
        Destroy(zoneLayer3);
    }

    IEnumerator layer4Drop()
    {
        layer4rb.useGravity = true;
        layer4rb.isKinematic = false;
        foreach (var item in layer4Assets)
        {
            item.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(zoneDestroyTimer);
        Destroy(zoneLayer4);
    }

    IEnumerator Layer5Drop()
    {
        layer5rb.useGravity = true;
        layer5rb.isKinematic = false;
        foreach (var item in layer5Assets)
        {
            item.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(zoneDestroyTimer);
        Destroy(zoneLayer5);
    }

    IEnumerator Layer6Drop()
    {
        layer6rb.useGravity = true;
        layer6rb.isKinematic = false;
        yield return new WaitForSeconds(zoneDestroyTimer);
        Destroy(zoneLayer6);
    }

    IEnumerator Layer7drop()
    {
        layer7rb.useGravity = true;
        layer7rb.isKinematic = false;
        yield return new WaitForSeconds(zoneDestroyTimer);
        Destroy(zoneLayer7);
       // yield return new WaitForSeconds(10);
        LastZone();
        
    }

    private void LastZone()
    {
        isLastZone = true;
        Vector3 newScale = lastZone.localScale - new Vector3(shrinkSpeed, shrinkSpeed, 0f) * Time.deltaTime;
        newScale = new Vector3(Mathf.Max(newScale.x, 0f), Mathf.Max(newScale.y, 0f),lastZone.localScale.z);
        lastZone.localScale = newScale;

    }

    void Update()
    {
        Timer();
        ShrinkZone();
        if(isLastZone)
        {
            LastZone();
        }
       

    }
}
