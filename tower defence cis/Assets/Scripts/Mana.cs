using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for mana generation

public class Mana : MonoBehaviour
{
    private int currentManaAmount;
    private int towerManaAmount;
    private int totalManaTowerLevel;
    private int numberOfManaTowers;

    private float manaGenerationRate;

    bool manaTowersExist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForManaTowers();

        if (manaTowersExist)
        {
            StartCoroutine("GenerateMana");
        }
        else if (!manaTowersExist)
        {
            StopCoroutine("GenerateMana");
        }

        Debug.Log("Mana: " + currentManaAmount);
    }

    private void CheckForManaTowers()
    {
        if (GameObject.FindGameObjectWithTag("ManaTower"))
        {
            manaTowersExist = true;
        }
            
    }

    private int DetermineTowerManaAmount()
    {
        towerManaAmount = totalManaTowerLevel * numberOfManaTowers;
        return towerManaAmount;
    }

    private void DetermineManaGenerationRate()
    {
        manaGenerationRate = DetermineTowerManaAmount() / 10;
    }

    private void AddMana()
    {
        currentManaAmount += DetermineTowerManaAmount();
    }
 
    IEnumerator GenerateMana()
    {
        DetermineManaGenerationRate();
        yield return new WaitForSeconds(manaGenerationRate);
        AddMana();
        yield return null;
    }
}
