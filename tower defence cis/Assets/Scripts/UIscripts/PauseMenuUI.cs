using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    // class object references set
    public GameObject pauseMenu;
    public PauseExitUI pExitOBJ;

    // button objects set
    public Button resumeButton;
    public Button menuButton;

    // variable set
    public static bool gameStopped = false;

    // Start is called before the first frame update
    private void Start()
    {
        // listeners for both buttons
        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(loadExitPrompt);

        // pause menu and exit prompt is inactive at start
        pauseMenu.SetActive(false);
        pExitOBJ.pauseExitPrompt.SetActive(false);

        // ensures game time is normal
        timeController.timeRate = 1f;

        // screen is active
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
                // game unpaused
                Resume();
            }
            else
            {
                //game paused
                Pause();
            }
        }
    }

    // action to resume game
    public void Resume()
    {
        // puase UI disabled and game resumes
        pauseMenu.SetActive(false);
        timeController.timeRate = 1f;
        gameStopped = false;
        CameraScript.gameScreenActive = true;
    }

    // action to pause game
    void Pause()
    {
        // pause UI active and gameplay stops
        pauseMenu.SetActive(true);
        timeController.timeRate = 0f;
        gameStopped = true;
        CameraScript.gameScreenActive = false;
    }
}