using UnityEngine;

public class DynamicCamMulti : MonoBehaviour
{
    public GameObject[] players; // Array to hold player GameObjects
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
        Vector3 centroid = GetCentroidOfActivePlayers();
        if (centroid == Vector3.zero)
            return;

        float furthestDistance = GetFurthestDistance(centroid);
        float cameraDistance = Mathf.Lerp(minDistance, maxDistance, furthestDistance / maxDistance);
        Vector3 cameraDestination = centroid - cam.transform.forward * cameraDistance;

        // Smoothly move the camera to the new position
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cameraDestination, ref velocity, smoothTime);
    }

    Vector3 GetCentroidOfActivePlayers()
    {
        Vector3 sum = Vector3.zero;
        int count = 0;
        foreach (GameObject player in players)
        {
            if (player != null && player.activeInHierarchy)
            {
                sum += player.transform.position;
                count++;
            }
        }

        return count > 0 ? sum / count : Vector3.zero;
    }

    float GetFurthestDistance(Vector3 centroid)
    {
        float furthestDistance = 0f;
        foreach (GameObject player in players)
        {
            if (player != null && player.activeInHierarchy)
            {
                float distance = Vector3.Distance(centroid, player.transform.position);
                if (distance > furthestDistance)
                {
                    furthestDistance = distance;
                }
            }
        }
        return furthestDistance;
    }
}
