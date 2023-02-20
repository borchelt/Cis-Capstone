using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    // variables and objects set
    public Button startButton;
    public Button resetButton;
    public Button exitButton;

    private void Start()
    {
        // listeners are initiated
        startButton.onClick.AddListener(OnStart);
        resetButton.onClick.AddListener(ResetProgressPrompt);
        exitButton.onClick.AddListener(QuitGame);
    }

    // action to load the level select screen
    public void OnStart()
    {
        if (GameProgress.firstStart == true)
        {
            //load story UI. when player clicks 'okay', firstStart is set to false
        }
        else
        {
            // load level select
        }
    }

    // action to load the prompt for resetting game progress
    public void ResetProgressPrompt()
    {
        // load prompt

        /*
        if (yes)
        {
            GameProgress.ResetProgress();
            // exit out of prompt to main menu
        }
        if (no)
        {
            // exit out of prompt to main menu
        }
         */
    }

    // action to exit the game application
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}