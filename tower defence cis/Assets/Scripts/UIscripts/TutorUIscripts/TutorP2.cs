using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP2 : MonoBehaviour
{
    // Object set for script
    public GameObject tPage2;

    // class object references set
    public TutorP1 p1OBJ;
    public TutorP3 p3OBJ;
    public TutOBJ tut;
    public MainMenuUI mainMenuOBJ;

    // Button Objects set
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

    // Next to page 3
    public void onNext()
    {
        tPage2.SetActive(false);
        p3OBJ.tPage3.SetActive(true);
    }

    // back to page 1
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
