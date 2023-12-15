using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectionManager : MonoBehaviour
{
    public void SelectPlayersAndStartGame(int numberOfPlayers)
    {
        

        // Determine the scene based on number of players assigned later to the buttons
        string sceneName = "";
        switch (numberOfPlayers)
        {
            case 2:
                sceneName = "zone 2.3 2 player";
                break;
            case 3:
                sceneName = "zone 2.3 3 player";
                break;
            case 4:
                sceneName = "zone 2.3 4 player";
                break;

                //return;

            //I LOVE SWITCH CASES THEY LOOK SO CLEAN


        }

       
        SceneManager.LoadScene(sceneName);
    }
}
