using UnityEngine;
using UnityEngine.UI;

//This script is for adding mana to the total and displaying it on the UI

public class Mana : MonoBehaviour
{
    public  int currentManaAmount;
    public int manaCost;
    
    public GameObject manaBar;
    Text manaBarText;

    ManaTower manaTower;

    private void Start()
    {
        manaBarText = manaBar.GetComponent<Text>();
        manaTower = FindObjectOfType<ManaTower>();
    }

    public void AddMana()
    {
        currentManaAmount += manaTower.DetermineTowerManaAmount();
        UpdateManaBar();
    }

    public void UpdateManaBar()
    {
        manaBarText.text = currentManaAmount.ToString();
    }
}
