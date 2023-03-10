using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    // variables and objects initialized here
    public GameObject pauseMenu;

    public Button resumeButton;
    public Button menuButton;

    public static bool gameStopped = false;

    // actions done at start
    private void Start()
    {
        // listeners for both buttons
        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(loadExitPrompt);
    }

    // to go to the main menu scene
    public void loadExitPrompt()
    {
        // load prompt to exit level
        PauseExitUI.pauseExitPrompt.SetActive(false);
    }

    // done every game frame
    public void Update()
    {
        // pressing the esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // checks if game paused or not
            if (gameStopped)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // action to resume game
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameStopped = false;
    }

    // action to pause game
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameStopped = true;
    }
}