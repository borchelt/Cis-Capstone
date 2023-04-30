using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    // variables and objects set
    public static bool firstStart = true;
    public static bool level1Win = false;
    public static bool level2Win = false;
    public static bool level3Win = false;
    public static bool level4Win = false;
    public static bool level5Win = false;

    public static float l1;

    LevelSelectUI levelSelectOBJ;

    // Update is called once per frame
    void Update()
    {

        if (level1Win == true)
        {
            Debug.Log("Unlocked");
            levelSelectOBJ.level2Button.interactable = true;
        }
        else if (level1Win == false)
        {
            levelSelectOBJ.level2Button.interactable = false;
        }

        if (level2Win == true)
        {
            levelSelectOBJ.level3Button.interactable = true;
        }
        else if (level2Win == false)
        {
            levelSelectOBJ.level3Button.interactable = false;
        }

        if (level3Win == true)
        {
            levelSelectOBJ.level4Button.interactable = true;
        }
        else if (level3Win == false)
        {
            levelSelectOBJ.level4Button.interactable = false;
        }

        if (level4Win == true)
        {
            levelSelectOBJ.level5Button.interactable = true;
        }
        else if (level4Win == false)
        {
            levelSelectOBJ.level5Button.interactable = false;
        }
    }

    // action to reset all game progress
    public void ResetProgress()
    {
        // values are reset when player opts 'yes'
        firstStart = true;
        level1Win = false;
        level2Win = false;
        level3Win = false;
        level4Win = false;
        level5Win = false;
    }
}
