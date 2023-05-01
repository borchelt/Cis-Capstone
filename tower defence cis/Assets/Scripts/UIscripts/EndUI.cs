using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    // class object references set
    public GameObject endScreen;
    public MainMenuUI mainMenuOBJ;

    public Button okayButton;

    // listener is initiated
    void Start()
    {
        okayButton.onClick.AddListener(onOkay);
    }

    // exits to the level select screen
    public void onOkay()
    {
        // exit to level select
        endScreen.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);

        if(GameProgress.level5Win == true)
        {
            GameProgress.level5Win = false;
        }
    }
}
