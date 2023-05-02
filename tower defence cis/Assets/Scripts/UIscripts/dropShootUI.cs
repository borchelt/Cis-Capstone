using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropShootUI : MonoBehaviour
{
    // NOTE: The listeners for the buttons are in GameMechanic Script

    // button objects set
    public Button shoot1;
    public Button shoot2;
    public Button shoot3;
    public Button closeButton;

    // class object references set
    public GameObject dropShoot;
    public GameplayUI gameplayOBJ;

    // Script object set
    public GameObject selectedObj;

    // listener initiated. drop menu is closed at start
    void Start()
    {
        closeButton.onClick.AddListener(onClose);

        dropShoot.SetActive(false);
    }

    // checks placement
    void Update()
    {
        gameplayOBJ.placeCheck();
    }

    // closes drop menu
    public void onClose()
    {
        dropShoot.SetActive(false);
    }
}
