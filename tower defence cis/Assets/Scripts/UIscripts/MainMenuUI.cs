using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    // class object set
    public GameObject mainMenu;

    // button objects set
    public Button startButton;
    public Button resetButton;
    public Button exitButton;

    // class object references set
    public LevelSelectUI levelSelectOBJ;
    public StoryUI storyOBJ;
    public ResetPromptUI resetOBJ;
    public ExitGamePrompt exitOBJ;

    private void Start()
    {
        // menu ui is loaded in case it didn't load. Other UI is disabled at start
        mainMenu.SetActive(true);
        levelSelectOBJ.levelList.SetActive(false);
        storyOBJ.storyText.SetActive(false);
        resetOBJ.resetPrompt.SetActive(false);
        exitOBJ.exitGamePrompt.SetActive(false);

        // button listeners are initiated
        startButton.onClick.AddListener(OnStart);
        resetButton.onClick.AddListener(ResetProgressPrompt);
        exitButton.onClick.AddListener(QuitGamePrompt);

        // screen inactive
        CameraScript.gameScreenActive = false;
    }

    // action to load the level select screen
    public void OnStart()
    {
        mainMenu.SetActive(false);

        // When first selecting button, player is taken to story UI.
        if (GameProgress.firstStart == true)
        {
            // load story text
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
        resetOBJ.resetPrompt.SetActive(true);
    }

    // action to exit the game application
    public void QuitGamePrompt()
    {
        // load exit game prompt
       mainMenu.SetActive(false);
        exitOBJ.exitGamePrompt.SetActive(true);
    }
}