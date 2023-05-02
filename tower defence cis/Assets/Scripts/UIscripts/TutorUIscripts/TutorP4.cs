using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP4 : MonoBehaviour
{
    // Object set for script
    public GameObject tPage4;

    // class object references set
    public TutorP3 p3OBJ;
    public TutorP5 p5OBJ;
    public TutOBJ tut;
    public MainMenuUI mainMenuOBJ;

    public Button nextButton;
    public Button mainButton;
    public Button prevButton;

    // listeners are initiated
    void Start()
    {
        nextButton.onClick.AddListener(onNext);
        mainButton.onClick.AddListener(onMain);
        prevButton.onClick.AddListener(onPrev);
    }

    // Next to page 5
    public void onNext()
    {
        tPage4.SetActive(false);
        p5OBJ.tPage5.SetActive(true);
    }

    // back to page 3
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
