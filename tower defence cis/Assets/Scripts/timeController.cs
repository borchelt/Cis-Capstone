using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour
{
    public static float timeRate;
    //public float timeRate;                original line

    void Update()
    {
        Time.timeScale = timeRate;   
    }
}
