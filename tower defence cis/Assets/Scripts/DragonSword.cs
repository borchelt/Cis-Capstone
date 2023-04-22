using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for ending the game when the Dragon Sword takes too much damage

public class DragonSword : MonoBehaviour
{
    public EnemyTakeDamage damageScriptOBJ;
    //public WinLose wlOBJ;
    WinLose wlOBJ;


    private void Start()
    {
        wlOBJ = FindObjectOfType<WinLose>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damageScriptOBJ.hp <= 0)
        {
            wlOBJ.levelLose();
        }
    }
}
