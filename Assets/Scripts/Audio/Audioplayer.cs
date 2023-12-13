using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioplayer : MonoBehaviour
{
    [SerializeField] AudioSource powerUp_PickUp;
    [SerializeField] AudioSource explosionPower_Up;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource dizzy_PowerUp;
    [SerializeField] AudioSource hitting_tree;
    [SerializeField] AudioSource zoneShrink;
    [SerializeField] AudioSource timer;
    
    public void PowerUP()
    {
        powerUp_PickUp.Play();

    }

    public void Explosion()
    {
        explosionPower_Up.Play();
    }

    public void Jump_audio()
    {
        jumpSound.Play();
    }

    public void Dizzy()
    {
        dizzy_PowerUp.Play();
    }

    public void Tree_Falling()
    {
        hitting_tree.Play();
    }

    public void Zone_Shrink()
    {
        zoneShrink.Play();
    }

    public void TimeWarp()
    {
        timer.Play();
    }




}
