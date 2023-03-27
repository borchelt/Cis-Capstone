using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for mana generation and usage

public class Mana : MonoBehaviour
{
    private int towerManaAmount;
    private int currentManaAmount;
    private int boostedTowerManaAmount;
    private int numberOfManaTowers;
    private int towerLevel;
    private int manaCost;

    private float manaGenerationRate;
    private float boostedManaGenerationRate;

    bool manaTowersExist;
    bool useSpell;
    bool buildTower;
    bool upgradeTower;

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
    }

    private void CheckForManaTowers()
    {
        if (GameObject.FindGameObjectWithTag("ManaTower"))
        {
            manaTowersExist = true;
        }

        numberOfManaTowers = GameObject.FindGameObjectsWithTag("ManaTower").Length;
    }

    private int DetermineTowerManaAmount()
    {
        for (int i = 0; i < numberOfManaTowers; i++)
        {
            if (towerLevel == 1)
            {
                boostedTowerManaAmount += 10;
            }
            else if (towerLevel == 2)
            {
                boostedTowerManaAmount += 20;
            }
            else if (towerLevel == 3)
            {
                boostedTowerManaAmount += 40;
            }
            else if (towerLevel == 4)
            {
                boostedTowerManaAmount += 80;
            }
            else if (towerLevel == 5)
            {
                boostedTowerManaAmount += 160;
            }

            towerManaAmount += boostedTowerManaAmount;
        }

        towerManaAmount = 70 + boostedTowerManaAmount;
        return towerManaAmount;
    }

    private void DetermineManaGenerationRate()
    {
        for (int i = 0; i < numberOfManaTowers; i++)
        {
            if (towerLevel == 1)
            {
                boostedManaGenerationRate += 0.5f;
            }
            else if (towerLevel == 2)
            {
                boostedManaGenerationRate += 1.0f;
            }
            else if (towerLevel == 3)
            {
                boostedManaGenerationRate += 2.0f;
            }
            else if (towerLevel == 4)
            {
                boostedManaGenerationRate += 4.0f;
            }
            else if (towerLevel == 5)
            {
                boostedManaGenerationRate += 8.0f;
            }

            boostedManaGenerationRate += boostedManaGenerationRate;
        }
        
        manaGenerationRate = 100 / (1 + boostedManaGenerationRate);
    }

    private int DetermineManaCostAmount()
    {
        if (useSpell)
        {
            manaCost = 3000;
        }
        else if (buildTower)
        {
            manaCost = 1000;
        }
        else if (upgradeTower)
        {
            if (towerLevel == 1)
            {
                manaCost = 500;
            }
            else if (towerLevel == 2)
            {
                manaCost = 1000;
            }
            else if (towerLevel == 3)
            {
                manaCost = 3000;
            }
            else if (towerLevel == 4)
            {
                manaCost = 12000;
            }
            else if (towerLevel == 5)
            {
                manaCost = 60000;
            }
        }

        return manaCost;
    }

    private void AddMana()
    {
        currentManaAmount += DetermineTowerManaAmount();
    }

    private void LoseMana()
    {
        manaCost = DetermineManaCostAmount();
        currentManaAmount -= manaCost;
    }
 
    IEnumerator GenerateMana()
    {
        DetermineManaGenerationRate();
        yield return new WaitForSeconds(manaGenerationRate);
        AddMana();
        yield return null;
    }
}
