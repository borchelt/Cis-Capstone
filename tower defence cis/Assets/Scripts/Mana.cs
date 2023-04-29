using UnityEngine;
using UnityEngine.UI;

//This script is for adding mana to the total and displaying it on the UI

public class Mana : MonoBehaviour
{
    public  int currentManaAmount; //Total amount of mana available to player
    
    public GameObject manaCounter; //Reference for ManaCounter 
    Text manaCounterText; //Reference for text component on ManaCounter




    private void Awake()
    {
        manaCounterText = manaCounter.GetComponent<Text>();
        Debug.Log("mana: " + manaCounterText);
        manaCounterText.text = currentManaAmount.ToString();
    }

    /*
    Adds mana to the current mana total after getting 
    amount from ManaTower script
    */
    public void AddMana(int manaAmount)
    {
        Debug.Log("mana: adding mana");
        currentManaAmount += manaAmount;
        Debug.Log("mana: added mana");
        Debug.Log("mana: " + currentManaAmount);
        UpdateManaBar();
        Debug.Log("mana: fully updated");
    }

    //Updates text in ManaCounter on GameMechUI
    public void UpdateManaBar()
    {
        Debug.Log("mana: starting update");
        manaCounterText.text = currentManaAmount.ToString();
        Debug.Log("mana: updated");
    }
}
