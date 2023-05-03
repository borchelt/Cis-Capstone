using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    //audio
    public AudioSource song;
    public AudioClip winAudio;
    public AudioClip loseAudio;
    bool hasplayed = false;
    // script object reference set
    public GameObject wlOBJ;

    // object references set
    public WinUI winOBJ;
    public LoseUI loseOBJ;
    public WaveManager waveManagerOBJ;

    // Variable for individual scene name
    public string sceneName;

    // object references for DragonSword and the relevant level boss
    public GameObject[] dragonSword;
    public GameObject[] levelBoss;

    // boolean variable for scene loading
    bool hasLoaded = false;

    // instances are set and catches the level name
    void Start()
    {
        winOBJ.winUI.SetActive(false);
        loseOBJ.loseUI.SetActive(false);

        getSceneName();
    }

    // checks if either the level boss or the DragonSword is destroyed
    void Update()
    {

        if (levelBoss == null && waveManagerOBJ.waveIndex >= 37)
        {
            levelWin();
        }

        if(dragonSword == null)
        {
            levelLose();
        }
        
    }

    // method that occurs when the player completing the level successfully
    public void levelWin()
    {
        if (!hasplayed)
        {
            song.Stop();
            song.clip = winAudio;
            song.Play();
            hasplayed = true;
        }
        // checks level name, then changes the level success state of that scene
        if (sceneName == "Level1")
            if(GameProgress.level1Win == false)
            {
                Debug.Log("Level 2 Unlocked");
                GameProgress.level1Win = true;
            }
        if (sceneName == "Level2")
            if (GameProgress.level2Win == false)
            {
                GameProgress.level2Win = true;
            }
        if (sceneName == "Level3")
            if (GameProgress.level3Win == false)
            {
                GameProgress.level3Win = true;
            }
        if (sceneName == "Level4")
            if (GameProgress.level4Win == false)
            {
                GameProgress.level4Win = true;
            }
        if (sceneName == "Level5")
            if (GameProgress.level5Win == false)
            {
                GameProgress.level5Win = true;
            }

        // "you win" screen is activated and the game stops for a few seconds to load back to main menu
        winOBJ.winUI.SetActive(true);
        StartCoroutine(waitTime(3));
    }

    // method that occurs when the player loses
    public void levelLose()
    {
        if(!hasplayed)
        {
            song.Stop();
            song.clip = loseAudio;
            song.Play();
            hasplayed = true;
        }
        

        // "you lose" screen is activated and the game stops for a few seconds to load back to main menu
        loseOBJ.loseUI.SetActive(true);
        StartCoroutine(waitTime(3));
    }

    // method that occurs before loading to the main menu
    private IEnumerator waitTime(float wait)
    {
        yield return new WaitForSecondsRealtime(wait);
        if(!hasLoaded)
        {
            GameSceneManager.Instance.LoadScene("MainMenu");
            hasLoaded = true;
        }
    }

    // method for receiving the level name
    public void getSceneName()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }
}
