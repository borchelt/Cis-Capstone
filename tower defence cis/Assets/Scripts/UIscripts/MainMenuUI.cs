using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    // script object reference set
    public GameObject mainMenu;

    // button objects set
    public Button startButton;
    public Button resetButton;
    public Button exitButton;
    public Button tutorButton;

    // class object references set
    public LevelSelectUI levelSelectOBJ;
    public StoryUI storyOBJ;
    public ResetPromptUI resetOBJ;
    public ExitGamePrompt exitOBJ;
    public EndUI endOBJ;

    // tutorial object references set
    public TutOBJ tut;
    public TutorP1 p1OBJ;

    // Start is called before the first frame update
    private void Start()
    {
        // menu ui is loaded in case it didn't load. Other UI in the Main Menu scene is disabled at start
        // NOTE: the coding that disables tutorial pages UI at start are in the TutOBJ class
        mainMenu.SetActive(true);
        levelSelectOBJ.levelList.SetActive(false);
        storyOBJ.storyText.SetActive(false);
        resetOBJ.resetPrompt.SetActive(false);
        exitOBJ.exitGamePrompt.SetActive(false);
        tut.tutOBJ.SetActive(false);

        // end screen appears after completing level 5
        if(GameProgress.level5Win == true)
        {
            endOBJ.endScreen.SetActive(true);
            mainMenu.SetActive(false);
        }
        else
        {
            endOBJ.endScreen.SetActive(false);
        }

        // button listeners are initiated
        startButton.onClick.AddListener(OnStart);
        resetButton.onClick.AddListener(ResetProgressPrompt);
        exitButton.onClick.AddListener(QuitGamePrompt);
        tutorButton.onClick.AddListener(OnTutor);

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

        if (GameProgress.level5Win == true)
        {
            // load story text
            endOBJ.endScreen.SetActive(true);
        }
    }

    // opens up the tutorial booklet
    public void OnTutor()
    {
        mainMenu.SetActive(false);
        tut.tutOBJ.SetActive(true);
        p1OBJ.tPage1.SetActive(true);
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