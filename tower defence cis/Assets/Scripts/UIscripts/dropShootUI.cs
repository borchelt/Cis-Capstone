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

    // Start is called before the first frame update
    void Start()
    {
        shoot1.onClick.AddListener(onS1);
        shoot2.onClick.AddListener(onS2);
        shoot3.onClick.AddListener(onS3);
        closeButton.onClick.AddListener(onClose);
    }

    public void onS1()
    {
        gameplayOBJ.startPlacement(1);
    }

    public void onS2()
    {
        gameplayOBJ.startPlacement(1);
    }

    public void onS3()
    {
        gameplayOBJ.startPlacement(1);
    }

    public void onClose()
    {
        dropShoot.SetActive(false);
    }
}
