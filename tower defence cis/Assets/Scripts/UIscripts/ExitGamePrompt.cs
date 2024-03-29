using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGamePrompt : MonoBehaviour
{
    // class object references set
    public GameObject exitGamePrompt;
    public MainMenuUI mainMenuOBJ;

    // button objects set
    public Button yesButton;
    public Button noButton;

    // listeners are initiated
    void Start()
    {
        yesButton.onClick.AddListener(OnYes);
        noButton.onClick.AddListener(OnNo);
    }

    // quits the game
    public void OnYes()
    {
        // in case it was not already, game realtime is stopped
        timeController.timeRate = 0f;
        Application.Quit();

        // Debug message
        Debug.Log("Game Quit");
    }

    // Cancels prompt
    public void OnNo()
    {
        // exit out of prompt to main menu
        exitGamePrompt.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
