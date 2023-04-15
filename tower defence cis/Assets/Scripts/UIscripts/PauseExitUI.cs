using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseExitUI : MonoBehaviour
{
    // class object references set
    public GameObject pauseExitPrompt;
    public PauseMenuUI pauseOBJ;

    // button objects set
    public Button yesButton;
    public Button noButton;

    // Start is called before the first frame update
    void Start()
    {
        // listeners set
        yesButton.onClick.AddListener(OnYes);
        noButton.onClick.AddListener(OnNo);

        // prompt deactivated on level start
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
