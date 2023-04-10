using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseExitUI : MonoBehaviour
{
    // variables and objects set
    public GameObject pauseExitPrompt;
    public PauseMenuUI pauseOBJ;
    //public MainMenuUI mainMenuOBJ;

    public Button yesButton;
    public Button noButton;

    // Start is called before the first frame update
    void Start()
    {
        yesButton.onClick.AddListener(OnYes);
        noButton.onClick.AddListener(OnNo);

        pauseExitPrompt.SetActive(false);
    }

    public void OnYes()
    {
        // exit to main menu
        GameSceneManager.Instance.LoadScene("MainMenu");
    }

    public void OnNo()
    {
        // exit out of prompt to pause menu
        pauseExitPrompt.SetActive(false);
        pauseOBJ.pauseMenu.SetActive(true);
    }
}
