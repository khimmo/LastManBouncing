using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwavePowerup : MonoBehaviour
{

    //public Transform camera;
    public Vector3 cameraLocation;
    private Camera cam;
    private void Start()
    {
        //mainCamera = Camera.main;
        cam = Camera.main;



    }

    private void Update()
    {
        //cameraLocation = camera.cameraPosition;
        //DynamicCamera camera = GetComponent<DynamicCamera>();
        //cameraLocation = camera.cameraPosition;
        transform.LookAt(cam.transform.position);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply power-up effects to the player
            NewBallMovementDP playerMovement = other.GetComponent<NewBallMovementDP>();
            playerMovement.HasShockwave();

            // Destroy the power-up object

            Destroy(gameObject);
        }
    }

}