using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropShootUI : MonoBehaviour
{
    // button objects set
    public Button shoot1;
    public Button shoot2;
    public Button shoot3;
    public Button closeButton;

    // class object references set
    public GameObject dropShoot;
    public GameplayUI gameplayOBJ;

    public GameObject selectedObj;
    BasicTowerScript towerScript;
    ProjectileScript ProjScript;

    // Start is called before the first frame update
    void Start()
    {
        shoot1.onClick.AddListener(onS1);
        shoot2.onClick.AddListener(onS2);
        shoot3.onClick.AddListener(onS3);
        closeButton.onClick.AddListener(onClose);

        dropShoot.SetActive(false);
    }

    void Update()
    {
        gameplayOBJ.placeCheck();
    }

        public void onS1()
    {
        /*
        gameplayOBJ.startPlacement(1);

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
        */
    }

    public void onS2()
    {
        //gameplayOBJ.startPlacement(8);
    }

    public void onS3()
    {
        //gameplayOBJ.startPlacement(9);
    }

    public void onClose()
    {
        dropShoot.SetActive(false);
    }
}
