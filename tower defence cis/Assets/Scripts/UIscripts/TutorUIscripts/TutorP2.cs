using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP2 : MonoBehaviour
{
    // class object references set
    public GameObject tPage2;
    public TutorP1 p1OBJ;
    public TutorP3 p3OBJ;
    public TutOBJ tut;
    public MainMenuUI mainMenuOBJ;

    public Button nextButton;
    public Button mainButton;
    public Button prevButton;

    // listener is initiated
    void Start()
    {
        nextButton.onClick.AddListener(onNext);
        mainButton.onClick.AddListener(onMain);
        prevButton.onClick.AddListener(onPrev);
    }

    public void onNext()
    {
        tPage2.SetActive(false);
        p3OBJ.tPage3.SetActive(true);
    }

    public void onPrev()
    {
        p1OBJ.tPage1.SetActive(true);
        tPage2.SetActive(false);
    }

    // exits to the Main menu
    public void onMain()
    {
        tut.tutOBJ.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
