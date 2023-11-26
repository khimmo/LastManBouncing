using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float minDistance = 10f; // Minimum distance for the camera zoom
    public float maxDistance = 50f; // Maximum distance for the camera zoom
    public float smoothTime = 0.5f; // Smoothing time for camera movement
    
    

    private Vector3 velocity = Vector3.zero;
    private Camera cam;
    //public Vector3 cameraPosition;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        // Find the midpoint between the two players
        Vector3 midpoint = (player1.position + player2.position) / 2;

        // Calculate the distance between the players
        float distance = Vector3.Distance(player1.position, player2.position);

        // Adjust the field of view or camera distance based on player distance
        float cameraDistance = Mathf.Lerp(minDistance, maxDistance, distance / maxDistance);
        Vector3 cameraDestination = midpoint - cam.transform.forward * cameraDistance;
        

        // Smoothly move the camera to the new position
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cameraDestination, ref velocity, smoothTime);

        
    }
}
