using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathHandler : MonoBehaviour
{
    public TextMeshProUGUI messageText; 

    private static int sphereScore = 0;
    private static int sphere2Score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HandlePlayerFellOff(other.gameObject);
        }
    }

    private void HandlePlayerFellOff(GameObject player)
    {
        // Update score based on which player fell off
        if (player.name == "Sphere")
        {
            sphere2Score++;
            UpdateMessage("Player 2 scores! Total score: " + sphereScore + " - " + sphere2Score);
        }
        else if (player.name == "Sphere2")
        {
            sphereScore++;
            UpdateMessage("Player 1 scores! Total score: " + sphereScore + " - " + sphere2Score);
        }

        // Restart the scene after a delay
        Invoke("RestartScene", 4f);
    }

    private void UpdateMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            Debug.Log("Updating message: " + message); 
            
        }
        else
        {
            Debug.LogError("messageText reference is null.");
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
