using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropMineUI : MonoBehaviour
{
    // NOTE: The listeners for the buttons are in GameMechanic Script

    // button objects set
    public Button M1;
    public Button M2;
    public Button M3;
    public Button closeButton;

    // class object references set
    public GameObject dropMine;
    public GameplayUI gameplayOBJ;

    // Script object set
    public GameObject selectedObj;

    // listener initiated. drop menu is closed at start
    void Start()
    {
        closeButton.onClick.AddListener(onClose);

        dropMine.SetActive(false);
    }

    // checks placement
    void Update()
    {
        gameplayOBJ.placeCheck();
    }

    // closes drop menu
    public void onClose()
    {
        dropMine.SetActive(false);
    }
}
