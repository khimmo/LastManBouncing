using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathHandler : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    private static int sphereScore = 0;
    private static int sphere2Score = 0;
    private bool deathOccurred = false;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    void Start()
    {
        UpdateScoreboard();
        UpdateIndividualScoreboard(player1ScoreText, sphereScore);
        UpdateIndividualScoreboard(player2ScoreText, sphere2Score);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !deathOccurred)
        {
            deathOccurred = true;
            HandlePlayerFellOff(other.gameObject);
            Invoke("RestartScene", 1f); // Delay before restarting the scene
        }
    }

    private void HandlePlayerFellOff(GameObject player)
    {
        if (player.name == "Sphere")
        {
            sphere2Score++;
            UpdateIndividualScoreboard(player2ScoreText, sphere2Score);
            
        }
        else if (player.name == "Sphere2")
        {
            sphereScore++;
            UpdateIndividualScoreboard(player1ScoreText, sphereScore);
            
        }

        UpdateScoreboard();
    }
    private void UpdateIndividualScoreboard(TextMeshProUGUI scoreText, int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }


    private void UpdateScoreboard()
    {
        if (messageText != null)
        {
            messageText.text = "Sphere: " + sphereScore + "- Sphere2: " + sphere2Score;
        }
    }

    private void RestartScene()
    {
        deathOccurred = false; // Reset the flag for the next round
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
