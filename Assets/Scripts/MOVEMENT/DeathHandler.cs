using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    // You can also use UnityEvents or a custom event system for more complex scenarios
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is a player
        if (other.gameObject.CompareTag("Player"))
        {
            HandlePlayerFellOff(other.gameObject);
        }
    }

    private void HandlePlayerFellOff(GameObject player)
    {
        
        Debug.Log(player.name + " fell off the map!");
        Destroy(player);

    }
}
