using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutOBJ : MonoBehaviour
{
    // Object set for script
    public GameObject tutOBJ;

    // Tutorial page references set
    public TutorP1 p1OBJ;
    public TutorP2 p2OBJ;
    public TutorP3 p3OBJ;
    public TutorP4 p4OBJ;
    public TutorP5 p5OBJ;
    public TutorP6 p6OBJ;

    // All pages are inactive at start. tutorButton in MainMenu activates first page
    private void Start()
    {
        p1OBJ.tPage1.SetActive(false);
        p2OBJ.tPage2.SetActive(false);
        p3OBJ.tPage3.SetActive(false);
        p4OBJ.tPage4.SetActive(false);
        p5OBJ.tPage5.SetActive(false);
        p6OBJ.tPage6.SetActive(false);
    }
}
