using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP1 : MonoBehaviour
{
    // class object references set
    public GameObject tPage1;
    public TutOBJ tut;
    public MainMenuUI mainMenuOBJ;

    public Button nextButton;
    public Button mainButton;

    // listener is initiated
    void Start()
    {
        nextButton.onClick.AddListener(onNext);
        mainButton.onClick.AddListener(onMain);
    }

    public void onNext()
    {
        /*
        tPage1.SetActive(false);
        tPage2.SetActive(true);
         */
    }

    // exits to the Main menu
    public void onMain()
    {
        tut.tutOBJ.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
