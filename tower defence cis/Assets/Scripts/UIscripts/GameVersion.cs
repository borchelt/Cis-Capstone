using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVersion : MonoBehaviour
{
    // variables and objects set
    public Text gameVersion;


    // finds Text object in Inspector
    void Start()
    {
        gameVersion = GetComponent<Text>();
    }

    // display current game version
    void Update()
    {
        gameVersion.text = "Version " + Application.version;
    }
}
