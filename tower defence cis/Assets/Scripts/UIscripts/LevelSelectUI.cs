using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    // variables and objects set
    public GameObject levelList;
    public MainMenuUI mainMenuOBJ;
    public StoryUI storyOBJ;

    public Button tutorButton;
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;
    public Button storyButton;
    public Button backButton;

    // listeners are initiated
    void Start()
    {
        tutorButton.onClick.AddListener(LoadTutorLevel);
        level1Button.onClick.AddListener(LoadLevel1);
        level2Button.onClick.AddListener(LoadLevel2);
        level3Button.onClick.AddListener(LoadLevel3);
        level4Button.onClick.AddListener(LoadLevel4);
        level5Button.onClick.AddListener(LoadLevel5);
        storyButton.onClick.AddListener(onStory);
        backButton.onClick.AddListener(onBack);
    }

    // selected tutorial level
    public void LoadTutorLevel()
    {
        //GameSceneManager.Instance.LoadScene("Tutorial");
    }

    // selected level 1
    public void LoadLevel1()
    {
        GameSceneManager.Instance.LoadScene("Level1");
    }

    // selected level 2
    public void LoadLevel2()
    {
        if (GameProgress.level1Win == true)
        {
            //GameSceneManager.Instance.LoadScene("Level2");
        }
        else
        {
            // cancel load
        }
    }

    // selected level 3
    public void LoadLevel3()
    {
        if (GameProgress.level2Win == true)
        {
            //GameSceneManager.Instance.LoadScene("Level3");
        }
        else
        {
            // cancel load
        }
    }

    // selected level 4
    public void LoadLevel4()
    {
        if (GameProgress.level3Win == true)
        {
            //GameSceneManager.Instance.LoadScene("Level4");
        }
        else
        {
            // cancel load
        }
    }

    // selected level 5
    public void LoadLevel5()
    {
        if (GameProgress.level4Win == true)
        {
            //GameSceneManager.Instance.LoadScene("Level5");
        }
        else
        {
            // cancel load
        }
    }

    // selected story
    public void onStory()
    {
        // load story
        levelList.SetActive(false);
        storyOBJ.storyText.SetActive(true);
    }

    // go back to main menu
    public void onBack()
    {
        levelList.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }
}
