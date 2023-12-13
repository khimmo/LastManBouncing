using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathHandlerMP : MonoBehaviour
{
    public TextMeshProUGUI[] playerScoreTexts; // Array for each player's score

    private static int[] playerScores;
    private int activePlayers;
    private bool roundInProgress = true;

    void Start()
    {
        playerScores = new int[playerScoreTexts.Length];
        activePlayers = playerScoreTexts.Length; 
        UpdateAllScoreboards();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && roundInProgress)
        {
            activePlayers--;
            other.gameObject.SetActive(false); 

            if (activePlayers == 1)
            {
                // Award point to the last player standing
                AwardPointToLastPlayerStanding();
                Invoke("RestartScene", 1f); // Delay before restarting the scene
            }
        }
    }

    private void AwardPointToLastPlayerStanding()
    {
        for (int i = 0; i < playerScoreTexts.Length; i++)
        {
            if (playerScoreTexts[i].gameObject.activeInHierarchy) // Check if the player is still active
            {
                playerScores[i]++;
                UpdateIndividualScoreboard(playerScoreTexts[i], playerScores[i]);
                break; // Stop checking once the last player is found
            }
        }
        roundInProgress = false; // End the current round
    }

    private void UpdateIndividualScoreboard(TextMeshProUGUI scoreText, int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateAllScoreboards()
    {
        for (int i = 0; i < playerScores.Length; i++)
        {
            UpdateIndividualScoreboard(playerScoreTexts[i], playerScores[i]);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        roundInProgress = true; // Reset for the new round
    }
}
