using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpinner : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //spins the object
        transform.Rotate(0, 0, 3, Space.Self);
    }
}
