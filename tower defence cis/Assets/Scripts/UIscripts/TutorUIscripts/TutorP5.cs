using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP5 : MonoBehaviour
{
    // Object set for script
    public GameObject tPage5;

    // class object references set
    public TutorP4 p4OBJ;
    public TutorP6 p6OBJ;
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

    // Next to page 6
    public void onNext()
    {
        tPage5.SetActive(false);
        p6OBJ.tPage6.SetActive(true);
    }

    // back to page 4
    public void onPrev()
    {
        p4OBJ.tPage4.SetActive(true);
        tPage5.SetActive(false);
    }

    // exits to the Main menu
    public void onMain()
    {
        tut.tutOBJ.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
