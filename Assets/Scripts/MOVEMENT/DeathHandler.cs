using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathHandler : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    private static int sphereScore = 0;
    private static int sphere2Score = 0;
    private bool deathOccurred = false;

    void Start()
    {
        UpdateScoreboard();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !deathOccurred)
        {
            deathOccurred = true;
            HandlePlayerFellOff(other.gameObject);
            Invoke("RestartScene", 2f); // Delay before restarting the scene
        }
    }

    private void HandlePlayerFellOff(GameObject player)
    {
        if (player.name == "Sphere")
        {
            sphere2Score++;
        }
        else if (player.name == "Sphere2")
        {
            sphereScore++;
        }

        UpdateScoreboard();
    }

    private void UpdateScoreboard()
    {
        if (messageText != null)
        {
            messageText.text = "Sphere: " + sphereScore + " - Sphere2: " + sphere2Score;
        }
    }

    private void RestartScene()
    {
        deathOccurred = false; // Reset the flag for the next round
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
