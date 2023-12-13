using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);

        /* Get the number of players
        int numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers", 2);

        Spawn the players
       /for (int i = 0; i < numberOfPlayers; i++)
        {
            if (i < spawnPoints.Length)
            {
                GameObject newPlayer = Instantiate(playerPrefab, spawnPoints[i].position, spawnPoints[i].rotation);

                // Assign the correct PlayerNumber
                MovementDPMP playerScript = newPlayer.GetComponent<MovementDPMP>();
                if (playerScript != null)
                {
                    playerScript.playerNumber = (MovementDPMP.PlayerNumber)i;
                }
            } 
        } */
    }

    void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}