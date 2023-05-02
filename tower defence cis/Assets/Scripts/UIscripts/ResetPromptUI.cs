using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPromptUI : MonoBehaviour
{
    // class object set
    public GameObject resetPrompt;

    // button objects set
    public Button yesButton;
    public Button noButton;

    // MainMenuUI object to access the class object
    public MainMenuUI mainMenuOBJ;

    // listeners are initiated
    void Start()
    {
        yesButton.onClick.AddListener(OnYes);
        noButton.onClick.AddListener(OnNo);
    }

    // resets progress and exits out of prompt
    public void OnYes()
    {
        // game progress resets
        GameProgress.ResetProgress();

        // exit out of prompt to main menu
        resetPrompt.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }

    // Cancels prompt
    public void OnNo()
    {
        // exit out of prompt to main menu
        resetPrompt.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
