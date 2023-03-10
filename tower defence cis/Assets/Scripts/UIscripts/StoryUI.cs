using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUI : MonoBehaviour
{
    // variables and objects set
    public static GameObject storyText;
    public Button okayButton;

    // listeners are initiated
    void Start()
    {
        okayButton.onClick.AddListener(onOkay);
    }

    // exits to the level select screen
    public void onOkay()
    {
        // exit to level select
        storyText.SetActive(false);
        MainMenuUI.mainMenu.SetActive(true);
    }
}
