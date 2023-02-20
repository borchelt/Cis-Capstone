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

    // Update is called once per frame
    void Update()
    {
        /*
        if (level1Win == true)
        {
            level2Unlock();
        }
        if (level2Win == true)
        {
            level3Unlock();
        }
        if (level3Win == true)
        {
            level4Unlock();
        }
        if (level4Win == true)
        {
            level5Unlock();
        }
         */
    }

    // action to reset all game progress
    public static void ResetProgress()
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
