using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoss : MonoBehaviour
{
    // object references set
    public EnemyTakeDamage damageScriptOBJ;
    WinLose wlOBJ;

    // WinLose object reference is set
    private void Start()
    {
        wlOBJ = FindObjectOfType<WinLose>();
    }

    // checks the status of the level boss. if destroyed, the player wins
    void Update()
    {
        if (damageScriptOBJ.hp <= 0)
        {
            wlOBJ.levelWin();
        }
    }
}
