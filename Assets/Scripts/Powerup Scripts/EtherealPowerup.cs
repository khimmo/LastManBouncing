using UnityEngine;

public class EtherealPowerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPowerupManager powerupManager = other.GetComponent<PlayerPowerupManager>();
            if (powerupManager != null)
            {
                powerupManager.CollectEtherealPowerup();
                Destroy(gameObject); // Destroy the power-up object
            }
        }
    }
}
