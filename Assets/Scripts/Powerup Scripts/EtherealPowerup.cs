using System.Collections;
using UnityEngine;

public class EtherealPowerup : MonoBehaviour
{
    public float duration = 1f; // Duration of the ethereal effect

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assign the power-up effect to the player
            PlayerPowerup playerPowerup = other.GetComponent<PlayerPowerup>();
            if (playerPowerup != null)
            {
                playerPowerup.SetEtherealPowerup(this);
            }

            gameObject.SetActive(false);
        }
    }

    public void ActivateEthereal(Collider playerCollider)
    {
        StartCoroutine(ApplyEthereal(playerCollider));
    }

    private IEnumerator ApplyEthereal(Collider playerCollider)
    {
        if (playerCollider != null)
        {
            // Disable the player's collider
            playerCollider.enabled = false;

            // Wait for the duration of the power-up effect
            yield return new WaitForSeconds(duration);

            // Reenable the player's collider
            playerCollider.enabled = true;
        }

        Destroy(gameObject);
    }
}
