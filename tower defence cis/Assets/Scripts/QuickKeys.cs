using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickKeys : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // pressing the A key
        if (Input.GetKey("q"))
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectSpell();
            }
        }

        // pressing the 1 key
        if (Input.GetKey("1"))
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConEco();
            }
        }

        // pressing the 2 key
        if (Input.GetKey("2"))
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConBasic();
            }
        }

        // pressing the 3 key
        if (Input.GetKey("3"))
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConBrrks();
            }
        }

        // pressing the 4 key
        if (Input.GetKey("4"))
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConBomb();
            }
        }

        // pressing the 5 key
        if (Input.GetKey("5"))
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConLight();
            }
        }

        // pressing the 6 key
        if (Input.GetKey("6"))
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConMage();
            }
        }

        // pressing the 7 key
        if (Input.GetKey("7"))
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConWall();
            }
        }

        // pressing the 8 key
        if (Input.GetKey("8")) //&& pitTLeft != 0
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConPitT();
            }
        }

        // pressing the 9 key
        if (Input.GetKey("9")) //&& spikeTLeft != 0
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConSpikeT();
            }
        }

        // pressing the 0 key
        if (Input.GetKey("0")) //&& mineTLeft != 0
        {
            // checks if game paused or not
            if (CameraScript.gameScreenActive == true)
            {
                //SelectConMineT();
            }
        }
    }
}
