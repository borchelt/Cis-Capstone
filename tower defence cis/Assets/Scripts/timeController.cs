using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour
{
    public float timeRate;

    void Update()
    {
        Time.timeScale = timeRate;   
    }
}
