using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for ending the game when the Dragon Sword takes too much damage

public class DragonSword : MonoBehaviour
{
    // object references set
    public EnemyTakeDamage damageScriptOBJ;
    WinLose wlOBJ;

    // sets the WinLose object refrence
    private void Start()
    {
        wlOBJ = FindObjectOfType<WinLose>();
    }

    // checks the status of the DragonSword. if destroyed, the player loses
    void Update()
    {
        if (damageScriptOBJ.hp <= 0)
        {
            wlOBJ.levelLose();
        }
    }
}
