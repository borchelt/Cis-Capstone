using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public static bool firstStart = true;
    public static bool level1Win = false;
    public static bool level2Win = false;
    public static bool level3Win = false;
    public static bool level4Win = false;
    public static bool level5Win = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
