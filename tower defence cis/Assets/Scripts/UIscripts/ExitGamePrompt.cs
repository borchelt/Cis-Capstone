using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGamePrompt : MonoBehaviour
{
    // variables and objects set
    public static GameObject exitGamePrompt;

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
        Time.timeScale = 1f;
        Application.Quit();
    }

    // Cancels prompt
    public void OnNo()
    {
        // exit out of prompt to main menu
        exitGamePrompt.SetActive(false);
        MainMenuUI.mainMenu.SetActive(true);
    }
}
