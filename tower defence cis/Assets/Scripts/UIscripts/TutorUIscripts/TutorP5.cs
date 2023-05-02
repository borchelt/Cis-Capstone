using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP5 : MonoBehaviour
{
    // class object references set
    public GameObject tPage5;
    public TutorP4 p4OBJ;
    public TutorP6 p6OBJ;
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
        tPage5.SetActive(false);
        p6OBJ.tPage6.SetActive(true);
    }

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
