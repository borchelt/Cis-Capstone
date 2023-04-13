using UnityEngine;
using UnityEngine.UI;

//This script is for adding mana to the total and displaying it on the UI

public class Mana : MonoBehaviour
{
    public  int currentManaAmount; //Total amount of mana available to player
    
    public GameObject manaCounter; //Reference for ManaCounter 
    Text manaCounterText; //Reference for text component on ManaCounter

    ManaTower manaTower; //Reference for the ManaTower script


    private void Start()
    {
        manaCounterText = manaCounter.GetComponent<Text>();
        manaTower = FindObjectOfType<ManaTower>();
    }

    /*
    Adds mana to the current mana total after getting 
    amount from ManaTower script
    */
    public void AddMana()
    {
        currentManaAmount += manaTower.DetermineTowerManaAmount();
        UpdateManaBar();
    }

    //Updates text in ManaCounter on GameMechUI
    public void UpdateManaBar()
    {
        manaCounterText.text = currentManaAmount.ToString();
    }
}
