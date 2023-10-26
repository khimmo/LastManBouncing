using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Reference to the player's Transform
    public Vector3 offset = new Vector3(0f, 5f, -10f);  // Camera offset from the player
    public float smoothSpeed = 5f; // Speed at which the camera follows the player

    private void LateUpdate()
    {
        // Calculate the desired camera position based on the player's position and offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Make the camera look at the player (optional)
        transform.LookAt(target);
    }
}
