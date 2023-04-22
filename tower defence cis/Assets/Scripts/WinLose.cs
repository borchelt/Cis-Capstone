using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public GameObject wlOBJ;
    public WinUI winOBJ;
    public LoseUI loseOBJ;
    //public WaveManager waveManagerOBJ;

    // Variable for individual scene name
    public string sceneName;

    //public GameObject[] dragonSword;
    //public GameObject[] levelBoss;

    // Start is called before the first frame update
    void Start()
    {
        winOBJ.winUI.SetActive(false);
        loseOBJ.loseUI.SetActive(false);

        //getSceneName();
        //getDragon();
        //getBoss();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(levelBoss == null && waveManagerOBJ.waveIndex >= 37)
        {
            levelWin();
        }

        if(dragonSword == null)
        {
            levelLose();
        }
        */
    }

    public void levelWin()
    {
        if(sceneName == "level1")
            if(GameProgress.level1Win == false)
            {
                GameProgress.level1Win = true;
            }
        if (sceneName == "level2")
            if (GameProgress.level2Win == false)
            {
                GameProgress.level2Win = true;
            }
        if (sceneName == "level3")
            if (GameProgress.level3Win == false)
            {
                GameProgress.level3Win = true;
            }
        if (sceneName == "level4")
            if (GameProgress.level4Win == false)
            {
                GameProgress.level4Win = true;
            }
        if (sceneName == "level5")
            if (GameProgress.level5Win == false)
            {
                GameProgress.level5Win = true;
            }

        winOBJ.winUI.SetActive(true);
        StartCoroutine(waitTime(3));
    }

    public void levelLose()
    {
        loseOBJ.loseUI.SetActive(true);
        StartCoroutine(waitTime(3));
    }

    private IEnumerator waitTime(float wait)
    {
        yield return null;
        timeController.timeRate = 0f; // game is paused
        yield return new WaitForSecondsRealtime(wait);
        GameSceneManager.Instance.LoadScene("MainMenu");
    }
    public void getSceneName()
    {
        //sceneName = scene
    }

    /*
    public void getBoss()
    {
        if(sceneName == "level1")
        {
            levelBoss = GameObject.FindGameObjectsWithTag("firstBoss");
        }
    }

    public void getDragon()
    {
        dragonSword = GameObject.FindGameObjectsWithTag("DragonSword");
    }
    */
}
