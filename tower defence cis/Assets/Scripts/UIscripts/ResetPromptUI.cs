using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPromptUI : MonoBehaviour
{
    // variables and objects set
    public Button yesButton;
    public Button noButton;

    // listeners are initiated
    void Start()
    {
        yesButton.onClick.AddListener(OnYes);
        noButton.onClick.AddListener(OnNo);
    }

    // resets progress and exits out of prompt
    public void OnYes()
    {
        GameProgress.ResetProgress();
        // exit out of prompt to main menu
    }

    // Cancels prompt
    public void OnNo()
    {
        // exit out of prompt to main menu
    }
}
