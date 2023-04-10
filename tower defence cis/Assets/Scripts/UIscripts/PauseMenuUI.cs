using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    // variables and objects initialized here
    public GameObject pauseMenu;
    public PauseExitUI pExitOBJ;

    public Button resumeButton;
    public Button menuButton;

    public static bool gameStopped = false;

    // actions done at start
    private void Start()
    {
        // listeners for both buttons
        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(loadExitPrompt);

        // pause menu is inactive at start
        pauseMenu.SetActive(false);
        pExitOBJ.pauseExitPrompt.SetActive(false);
        timeController.timeRate = 1f;
        CameraScript.gameScreenActive = true;
    }

    // to go to the main menu scene
    public void loadExitPrompt()
    {
        // load prompt to exit level
        pauseMenu.SetActive(false);
        pExitOBJ.pauseExitPrompt.SetActive(true);
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
        timeController.timeRate = 1f;
        gameStopped = false;
        CameraScript.gameScreenActive = true;
    }

    // action to pause game
    void Pause()
    {
        pauseMenu.SetActive(true);
        timeController.timeRate = 0f;
        gameStopped = true;
        CameraScript.gameScreenActive = false;
    }
}