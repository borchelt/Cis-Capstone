using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropAoeUI : MonoBehaviour
{
    // button objects set
    public Button aoe1;
    public Button aoe2;
    public Button aoe3;
    public Button closeButton;

    // class object references set
    public GameObject dropAOE;
    public GameplayUI gameplayOBJ;

    // Start is called before the first frame update
    void Start()
    {
        aoe1.onClick.AddListener(onAOE1);
        aoe2.onClick.AddListener(onAOE2);
        aoe3.onClick.AddListener(onAOE3);
        closeButton.onClick.AddListener(onClose);

        dropAOE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameplayOBJ.placeCheck();
    }

    public void onAOE1()
    {
        gameplayOBJ.startPlacement(3);
    }

    public void onAOE2()
    {
        //gameplayOBJ.startPlacement(10);
    }

    public void onAOE3()
    {
        //gameplayOBJ.startPlacement(11);
    }

    public void onClose()
    {
        dropAOE.SetActive(false);
    }
}
