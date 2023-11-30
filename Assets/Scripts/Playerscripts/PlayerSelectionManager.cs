using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectionManager : MonoBehaviour
{
    public void SelectNumberOfPlayers(int numberOfPlayers)
    {
        // Stores the number of players
        PlayerPrefs.SetInt("NumberOfPlayers", numberOfPlayers);

        // Load the game scene, ENTER THE NAME OF THE CURRENT MAIN SCENE HERE
        SceneManager.LoadScene("zone 2.1 Khalid 1");
    }
}
