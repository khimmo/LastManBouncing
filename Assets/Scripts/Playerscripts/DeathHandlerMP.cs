using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathHandlerMP : MonoBehaviour
{
    public GameObject[] playerObjects; // Array for player GameObjects
    public TextMeshProUGUI[] playerScoreTexts; // Array for each player score UI

    // Static scores for each player
    private static int scorePlayer1 = 0;
    private static int scorePlayer2 = 0;
    private static int scorePlayer3 = 0;
    private static int scorePlayer4 = 0; 

    private int activePlayers;
    private bool roundInProgress = true;

    void Start()
    {
        activePlayers = playerObjects.Length;
        UpdateAllScoreboards();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && roundInProgress)
        {
            int playerIndex = System.Array.IndexOf(playerObjects, other.gameObject);
            if (playerIndex != -1)
            {
                other.gameObject.SetActive(false);
                activePlayers--;

                if (activePlayers == 1)
                {
                    AwardPointToLastPlayerStanding();
                    Invoke("RestartScene", 1f);
                }
            }
        }
    }

    private void AwardPointToLastPlayerStanding()
    {
        for (int i = 0; i < playerObjects.Length; i++)
        {
            if (playerObjects[i].activeInHierarchy)
            {
                IncrementPlayerScore(i);
                UpdateIndividualScoreboard(playerScoreTexts[i], GetPlayerScore(i));
                break;
            }
        }
        roundInProgress = false;
    }

    private void IncrementPlayerScore(int playerIndex)
    {
        switch (playerIndex)
        {
            case 0: scorePlayer1++; break;
            case 1: scorePlayer2++; break;
            case 2: scorePlayer3++; break;
            case 3: scorePlayer4++; break;
                
        }
    }

    private int GetPlayerScore(int playerIndex)
    {
        switch (playerIndex)
        {
            case 0: return scorePlayer1;
            case 1: return scorePlayer2;
            case 2: return scorePlayer3;
            case 3: return scorePlayer4;
          
           default: return 0;
        }
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
        for (int i = 0; i < playerObjects.Length; i++)
        {
            UpdateIndividualScoreboard(playerScoreTexts[i], GetPlayerScore(i));
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        roundInProgress = true;
    }
}
