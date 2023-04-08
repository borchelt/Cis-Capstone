using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    // variables and objects set
    public GameObject mainMenu;

    public Button startButton;
    public Button resetButton;
    public Button exitButton;

    public LevelSelectUI levelSelectOBJ;
    public StoryUI storyOBJ;

    // listeners are initiated
    private void Start()
    {
        // menu ui is loaded in case it didn't load
        mainMenu.SetActive(true);
        levelSelectOBJ.levelList.SetActive(false);
        storyOBJ.storyText.SetActive(false);

        startButton.onClick.AddListener(OnStart);
        resetButton.onClick.AddListener(ResetProgressPrompt);
        exitButton.onClick.AddListener(QuitGamePrompt);

        CameraScript.gameScreenActive = false;
    }

    // action to load the level select screen
    public void OnStart()
    {
        mainMenu.SetActive(false);

        if (GameProgress.firstStart == true)
        {
            //load story UI. when player clicks 'okay', firstStart is set to false
            storyOBJ.storyText.SetActive(true);
        }
        else
        {
            // load level select
            levelSelectOBJ.levelList.SetActive(true);
        }
    }

    // action to load the prompt for resetting game progress
    public void ResetProgressPrompt()
    {
        // load prompt
        mainMenu.SetActive(false);
        ResetPromptUI.resetPrompt.SetActive(true);
    }

    // action to exit the game application
    public void QuitGamePrompt()
    {
        // load prompt
        mainMenu.SetActive(false);
        ExitGamePrompt.exitGamePrompt.SetActive(true);
    }
}