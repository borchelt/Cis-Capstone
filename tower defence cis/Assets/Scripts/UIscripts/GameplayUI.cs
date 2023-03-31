using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    // variables and objects set
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button spellButton;

    // listeners are initiated
    void Start()
    {
        button1.onClick.AddListener(on1);
        button2.onClick.AddListener(on2);
        button3.onClick.AddListener(on3);
        button4.onClick.AddListener(on4);
        button5.onClick.AddListener(on5);
        button6.onClick.AddListener(on6);
        spellButton.onClick.AddListener(onSpell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // activate placement for tower
    public void on1()
    {
        Debug.Log("button1");
    }

    // activate placement for tower
    public void on2()
    {
        Debug.Log("button2");
    }

    // activate placement for tower
    public void on3()
    {
        Debug.Log("button3");
    }

    // activate placement for tower
    public void on4()
    {
        Debug.Log("button4");
    }

    // activate placement for tower
    public void on5()
    {
        Debug.Log("button5");
    }

    // activate placement for trap
    public void on6()
    {

        Debug.Log("button6");
        /*
        if (trapnum >= 0)
        {

        }
        else
        {
            // no deactivate button listener for button 6
        }
        */
    }

    // activate spell use
    public void onSpell()
    {
        Debug.Log("spell");
        /*
        if(spellReady == true)
        {
            // activate spell placement
            spellReady = false;
        }
        else
        {
            // spell timer is still active
        }
        */
    }
}
