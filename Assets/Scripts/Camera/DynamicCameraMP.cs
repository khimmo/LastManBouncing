using UnityEngine;
using System.Collections.Generic;

public class DynamicCameraMP : MonoBehaviour
{
    public List<Transform> players = new List<Transform>();
    public float minDistance = 10f; // Minimum distance for the camera zoom
    public float maxDistance = 50f; // Maximum distance for the camera zoom
    public float smoothTime = 0.5f; // Smoothing time for camera movement

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (players.Count == 0)
            return;

        Vector3 centroid = GetCentroid();
        float furthestDistance = GetFurthestDistance(centroid);

        // Adjust the field of view or camera distance based on furthest player distance
        float cameraDistance = Mathf.Lerp(minDistance, maxDistance, furthestDistance / maxDistance);
        Vector3 cameraDestination = centroid - cam.transform.forward * cameraDistance;

        // Smoothly move the camera to the new position
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cameraDestination, ref velocity, smoothTime);
    }

    public void RegisterPlayer(Transform playerTransform)
    {
        if (!players.Contains(playerTransform))
        {
            players.Add(playerTransform);
        }
    }

    Vector3 GetCentroid()
    {
        if (players.Count == 0)
            return Vector3.zero;

        Vector3 centroid = Vector3.zero;
        foreach (Transform player in players)
        {
            centroid += player.position;
        }
        centroid /= players.Count;
        return centroid;
    }

    float GetFurthestDistance(Vector3 centroid)
    {
        float furthestDistance = 0f;
        foreach (Transform player in players)
        {
            float distance = Vector3.Distance(centroid, player.position);
            if (distance > furthestDistance)
                furthestDistance = distance;
        }
        return furthestDistance;
    }
}
