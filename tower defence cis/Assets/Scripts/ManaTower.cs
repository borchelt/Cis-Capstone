using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaTower : MonoBehaviour
{
    Mana manaManager;
    public int GenAmount;
    public float genCd;
    public float cd;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        manaManager = FindObjectOfType<Mana>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cd <= 0f)
            genMana();
        else
            cd -= Time.deltaTime;
    }

    void genMana()
    {
        manaManager.currentManaAmount += GenAmount;
        cd = genCd;
    }
}
