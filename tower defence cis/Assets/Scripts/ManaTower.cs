using System.Collections;
using UnityEngine;

//This script is for the Mana Towers to generate mana

public class ManaTower : MonoBehaviour
{
    Mana manaManager;

    public int manaTowerLevel;

    private int towerManaAmount;
    private int boostedTowerManaAmount;

    private float manaGenerationRate;
    private float boostedManaGenerationRate;

    private bool makeMana = true;

    // Start is called before the first frame update
    void Start()
    {
        manaManager = FindObjectOfType<Mana>();
        StartCoroutine(GenerateMana());
    }

    public int DetermineTowerManaAmount()
    {
        if (manaTowerLevel == 1)
        {
            boostedTowerManaAmount = 10;
        }
        else if (manaTowerLevel == 2)
        {
            boostedTowerManaAmount = 20;
        }
        else if (manaTowerLevel == 3)
        {
            boostedTowerManaAmount = 40;
        }
        else if (manaTowerLevel == 4)
        {
            boostedTowerManaAmount = 80;
        }
        else if (manaTowerLevel == 5)
        {
            boostedTowerManaAmount = 160;
        }

        towerManaAmount = 70 + boostedTowerManaAmount;
        return towerManaAmount;
    }

    private void DetermineManaGenerationRate()
    {
        if (manaTowerLevel == 1)
        {
            boostedManaGenerationRate = 0.5f;
        }
        else if (manaTowerLevel == 2)
        {
            boostedManaGenerationRate = 1.0f;
        }
        else if (manaTowerLevel == 3)
        {
            boostedManaGenerationRate = 2.0f;
        }
        else if (manaTowerLevel == 4)
        {
            boostedManaGenerationRate = 4.0f;
        }
        else if (manaTowerLevel == 5)
        {
            boostedManaGenerationRate = 8.0f;
        }

        manaGenerationRate = 10 / (1 + boostedManaGenerationRate);
    }

    IEnumerator GenerateMana()
    {
        while (makeMana)
        {
            DetermineManaGenerationRate();
            manaManager.AddMana();
            yield return new WaitForSeconds(manaGenerationRate);
        }
    }

}
