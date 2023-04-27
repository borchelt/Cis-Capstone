using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDISABLE : MonoBehaviour
{
    public GameObject disable;

    public testWL wlOBJ;
    public testStruct structOBJ;
    public testPrompts promptsOBJ;
    public testMech mechOBJ;
    public testDrop dropOBJ;
    public testPause pauseOBJ;

    // Start is called before the first frame update
    void Start()
    {
        structOBJ.structt.SetActive(false);
        promptsOBJ.prompts.SetActive(false);
        //mechOBJ.mech.SetActive(false);
        //dropOBJ.drop.SetActive(false);
        wlOBJ.wlUI.SetActive(false);
        pauseOBJ.pause.SetActive(false);
    }

}
