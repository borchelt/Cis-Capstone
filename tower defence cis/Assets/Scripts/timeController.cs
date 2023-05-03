using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour
{
    public static float timeRate;

    //keeps the time consistent 
    void Update()
    {
        Time.timeScale = timeRate;   
    }
}
