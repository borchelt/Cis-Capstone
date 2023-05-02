using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP4 : MonoBehaviour
{
    // class object references set
    public GameObject tPage4;
    public TutorP3 p3OBJ;
    public TutorP5 p5OBJ;
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
        tPage4.SetActive(false);
        p5OBJ.tPage5.SetActive(true);
    }

    public void onPrev()
    {
        p3OBJ.tPage3.SetActive(true);
        tPage4.SetActive(false);
    }

    // exits to the Main menu
    public void onMain()
    {
        tut.tutOBJ.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
