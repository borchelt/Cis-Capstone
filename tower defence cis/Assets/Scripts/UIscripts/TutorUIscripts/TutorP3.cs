using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP3 : MonoBehaviour
{
    // class object references set
    public GameObject tPage3;
    public TutorP2 p2OBJ;
    public TutorP4 p4OBJ;
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
        tPage3.SetActive(false);
        p4OBJ.tPage4.SetActive(true);
    }

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
