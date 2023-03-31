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

    private string structureName;

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
                if (structureName == "Mana Tower")
                {
                    manaCost = 500;
                }
                else if (structureName == "Barracks")
                {
                    manaCost = 300;
                }
                else if (structureName == "Shooter Tower")
                {
                    manaCost = 450;
                }
                else if (structureName == "AOE Tower")
                {
                    manaCost = 700;
                }
                
            }
            else if (towerLevel == 2)
            {
                if (structureName == "Mana Tower")
                {
                    manaCost = 1000;
                }
                else if (structureName == "Barracks")
                {
                    manaCost = 600;
                }
                else if (structureName == "Shooter Tower")
                {
                    manaCost = 900;
                }
                else if (structureName == "AOE Tower")
                {
                    manaCost = 700;
                }
            }
            else if (towerLevel == 3)
            {
                if (structureName == "Mana Tower")
                {
                    manaCost = 3000;
                }
                else if (structureName == "Barracks")
                {
                    manaCost = 1800;
                }
                else if (structureName == "Shooter Tower")
                {
                    manaCost = 2700;
                }
                else if (structureName == "AOE Tower")
                {
                    manaCost = 4200;
                }
            }
            else if (towerLevel == 4)
            {
                if (structureName == "Mana Tower")
                {
                    manaCost = 12000;
                }
                else if (structureName == "Barracks")
                {
                    manaCost = 7200;
                }
                else if (structureName == "Shooter Tower")
                {
                    manaCost = 10800;
                }
                else if (structureName == "AOE Tower")
                {
                    manaCost = 16800;
                }
            }
            else if (towerLevel == 5)
            {
                if (structureName == "Mana Tower")
                {
                    manaCost = 60000;
                }
                else if (structureName == "Barracks")
                {
                    manaCost = 36000;
                }
                else if (structureName == "Shooter Tower")
                {
                    manaCost = 54000;
                }
                else if (structureName == "AOE Tower")
                {
                    manaCost = 84000;
                }
            }
        }

        return manaCost;
    }

    private void AddMana()
    {
        currentManaAmount += DetermineTowerManaAmount();
    }

    private void ReturnMana()
    {
        manaCost = DetermineManaCostAmount();
        currentManaAmount += (manaCost / towerLevel);
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
