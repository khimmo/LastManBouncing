using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioplayer : MonoBehaviour
{
    [SerializeField] AudioSource powerUp_PickUp;
    [SerializeField] AudioSource explosionPower_Up;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource dizzy_PowerUp;
    
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


}
