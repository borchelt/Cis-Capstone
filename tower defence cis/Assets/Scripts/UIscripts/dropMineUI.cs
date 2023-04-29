using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropMineUI : MonoBehaviour
{
    // button objects set
    public Button M1;
    public Button M2;
    public Button M3;
    public Button closeButton;

    // class object references set
    public GameObject dropMine;
    public GameplayUI gameplayOBJ;

    public GameObject selectedObj;
    BasicTowerScript towerScript;
    ProjectileScript ProjScript;

    // Start is called before the first frame update
    void Start()
    {
        M1.onClick.AddListener(onM1);
        M2.onClick.AddListener(onM2);
        M3.onClick.AddListener(onM3);
        closeButton.onClick.AddListener(onClose);

        dropMine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameplayOBJ.placeCheck();
    }

    public void onM1()
    {
        gameplayOBJ.startPlacement(5);

        if (selectedObj.GetComponent<BasicTowerScript>() != null)
        {
            towerScript = selectedObj.GetComponent<BasicTowerScript>();
            towerScript.active = false;
        }

        if (selectedObj.GetComponent<ProjectileScript>() != null)
        {
            ProjScript = selectedObj.GetComponent<ProjectileScript>();
            ProjScript.active = false;

        }
    }

    public void onM2()
    {
        //gameplayOBJ.startPlacement(13);
    }

    public void onM3()
    {
        //gameplayOBJ.startPlacement(14);
    }

    public void onClose()
    {
        dropMine.SetActive(false);
    }
}
