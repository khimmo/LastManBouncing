using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colourtransition : MonoBehaviour
{
    [SerializeField] Animator zone6_Animation;
    [SerializeField] Animator zone5_Animation;
    [SerializeField] Animator zone4_Animation;
    [SerializeField] Animator zone3_Animation;
    [SerializeField] Animator zone2_Animation;
    [SerializeField] Animator zone1_Animation;
    [SerializeField] Animator zone0_Animation;
    [SerializeField] ZoneShrink zoneShrink;


    public Audioplayer audioplayer;


    private void Start()
    {
        zoneShrink = FindObjectOfType<ZoneShrink>();
        audioplayer = FindAnyObjectByType<Audioplayer>();
    }

    public void PlayAnimation()
    {
        if (zoneShrink.timer <= 10f && zoneShrink.zoneIndex == 0)
        {
            zone6_Animation.enabled = true;
        }

        if (zoneShrink.timer <= 10f && zoneShrink.zoneIndex == 1)
        {
            zone5_Animation.enabled = true;
        }

        if (zoneShrink.timer <= 10f && zoneShrink.zoneIndex == 2)
        {
            zone4_Animation.enabled = true;
        }

        if (zoneShrink.timer <= 10f && zoneShrink.zoneIndex == 3)
        {
            zone3_Animation.enabled = true;
        }

        if (zoneShrink.timer <= 10f && zoneShrink.zoneIndex == 4)
        {
            zone2_Animation.enabled = true;
        }

        if (zoneShrink.timer <= 10f && zoneShrink.zoneIndex == 5)
        {
            zone1_Animation.enabled = true;
        }

        if (zoneShrink.timer <= 10f && zoneShrink.zoneIndex == 6)
        {
            zone0_Animation.enabled = true;
        }

    }

    private void Update()
    {
        PlayAnimation();
    }

}
