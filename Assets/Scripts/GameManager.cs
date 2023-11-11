using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    void Start()
    {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
    }

    void PauseGame()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
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

    void Update()
    {
        PauseGame();
    }
}
