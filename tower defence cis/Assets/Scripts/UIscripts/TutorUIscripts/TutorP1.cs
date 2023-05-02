using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorP1 : MonoBehaviour
{
    // Object set for script
    public GameObject tPage1;

    // class object references set
    public TutorP2 p2OBJ;
    public TutOBJ tut;
    public MainMenuUI mainMenuOBJ;

    // Button Objects set
    public Button nextButton;
    public Button mainButton;

    // listeners are initiated
    void Start()
    {
        nextButton.onClick.AddListener(onNext);
        mainButton.onClick.AddListener(onMain);
    }

    // Next to page 3
    public void onNext()
    {
        tPage1.SetActive(false);
        p2OBJ.tPage2.SetActive(true);
    }

    // exits to the Main menu
    public void onMain()
    {
        tut.tutOBJ.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
