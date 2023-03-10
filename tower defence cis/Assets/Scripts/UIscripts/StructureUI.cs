using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureUI : MonoBehaviour
{
    // variables and objects set
    public GameObject structureMenu;

    public Button upgradeButton;
    public Button moveButton;
    public Button sellButton;

    // listeners are initiated
    void Start()
    {
        upgradeButton.onClick.AddListener(onUpgrade);
        moveButton.onClick.AddListener(onMove);
        sellButton.onClick.AddListener(onSell);
    }

    // upgrade structure
    public void onUpgrade()
    {
        /*
        if(manaNum <= manaCost)
        {
            manaNum -= manaCost;

            // upgrade

            // deactivate button listener
            structureMenu.SetActive(false);
        }
        else
        {
            // not enough mana. no action taken
        }
        */
    }

    // moves units at tower area to another tower area
    public void onMove()
    {
        /*
        if(unitsInArea == true)
        {
            // select tower

            for (int i = 0; i < currAreaUnitNum; i++)
            {
                // move units to new area
            }
            
            structureMenu.SetActive(false);
        }
        else
        {
            // no units in area. select different tower
        }
        */
    }

    // sell structure
    public void onSell()
    {
        // sell
        structureMenu.SetActive(false);
    }
}
