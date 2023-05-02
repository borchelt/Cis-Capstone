using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP3 : MonoBehaviour
{
    // Object set for script
    public GameObject tPage3;

    // class object references set
    public TutorP2 p2OBJ;
    public TutorP4 p4OBJ;
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

    // Next to page 4
    public void onNext()
    {
        tPage3.SetActive(false);
        p4OBJ.tPage4.SetActive(true);
    }

    // back to page 2
    public void onPrev()
    {
        p2OBJ.tPage2.SetActive(true);
        tPage3.SetActive(false);
    }

    // exits to the Main menu
    public void onMain()
    {
        tut.tutOBJ.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
