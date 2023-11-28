using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBob : MonoBehaviour
{
    //public float rotationSpeed = 60f;
    public float bobbingHeight = 0.25f;
    public float bobbingSpeed = 3f;
    private bool isGrounded;



    //private new Vector3 startingHeight 

    private Vector3 originalPosition;

    private void Start()
    {

    }

    void Update()
    {





        if (isGrounded)
        {
            // Rotation
            //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Bobbing
            float bobbingOffset = Mathf.Sin(bobbingSpeed * Time.time) * bobbingHeight;
            transform.position = originalPosition + new Vector3(0f, bobbingOffset, 0f);
        }




    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the powerup collides with the ground
        if (collision.gameObject.CompareTag("GROUND"))
        {
            isGrounded = true;
            originalPosition = transform.position + new Vector3(0, 2 * bobbingHeight, 0);
        }


    }
}
