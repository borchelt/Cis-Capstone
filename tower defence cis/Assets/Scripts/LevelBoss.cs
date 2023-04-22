using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoss : MonoBehaviour
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
            wlOBJ.levelWin();
        }
    }
}
