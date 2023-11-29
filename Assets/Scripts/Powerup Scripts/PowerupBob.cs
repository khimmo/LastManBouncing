using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBob : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float bobbingHeight = 0.25f;
    public float bobbingSpeed = 3f;
    public bool landed;
    private Transform groundTransform;
    
    

    //private new Vector3 startingHeight 

    private Vector3 originalPosition;
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = new Vector3(transform.position.x, 25, transform.position.z);
        transform.position = startingPosition;
    }

    void Update()
    {

        






            if (landed)
            {
                // Rotation
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

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
            landed = true;
            originalPosition = transform.position + new Vector3(0, 2 * bobbingHeight, 0);

        }    

     
    }
}
