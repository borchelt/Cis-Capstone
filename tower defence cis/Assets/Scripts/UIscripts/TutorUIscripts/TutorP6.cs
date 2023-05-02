using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP6 : MonoBehaviour
{
    // class object references set
    public GameObject tPage6;
    public TutorP5 p5OBJ;
    public TutOBJ tut;
    public MainMenuUI mainMenuOBJ;

    public Button mainButton;
    public Button prevButton;

    // listener is initiated
    void Start()
    {
        mainButton.onClick.AddListener(onMain);
        prevButton.onClick.AddListener(onPrev);
    }

    public void onPrev()
    {
        p5OBJ.tPage5.SetActive(true);
        tPage6.SetActive(false);
    }

    // exits to the Main menu
    public void onMain()
    {
        tut.tutOBJ.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
