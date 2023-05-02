using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    // class object references set
    public GameObject endScreen;
    public MainMenuUI mainMenuOBJ;

    // script reference set
    public Button okayButton;

    // listener is initiated
    void Start()
    {
        okayButton.onClick.AddListener(onOkay);
    }

    // exits to the level select screen and resets level 5 win variable
    public void onOkay()
    {
        // exit to level select
        endScreen.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);

        // resets win variable, to prevent end screen showing up after beating any other level
        if(GameProgress.level5Win == true)
        {
            GameProgress.level5Win = false;
        }
    }
}
