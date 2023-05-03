using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    // class object references set
    public GameObject levelList;
    public MainMenuUI mainMenuOBJ;
    public StoryUI storyOBJ;

    // button objects set
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

        level1Button.onClick.AddListener(LoadLevel1);

        level2Button.onClick.AddListener(LoadLevel2);

        level3Button.onClick.AddListener(LoadLevel3);

        level4Button.onClick.AddListener(LoadLevel4);

        level5Button.onClick.AddListener(LoadLevel5);

        storyButton.onClick.AddListener(onStory);
        backButton.onClick.AddListener(onBack);
    }

    private void Update()
    {
        checkButton();
    }

    // selected level 1. Loads the level
    public void LoadLevel1()
    {
        
        GameSceneManager.Instance.LoadScene("Level1");
    }

    // selected level 2. Loads the level
    public void LoadLevel2()
    {
        if (GameProgress.level1Win)
            GameSceneManager.Instance.LoadScene("Level2");
    }

    // selected level 3. Loads the level
    public void LoadLevel3()
    {
        if (GameProgress.level2Win)
            GameSceneManager.Instance.LoadScene("Level3");
    }

    // selected level 4. Loads the level
    public void LoadLevel4()
    {
        if (GameProgress.level3Win)
            GameSceneManager.Instance.LoadScene("Level4");
    }

    // selected level 5. Loads the level
    public void LoadLevel5()
    {
        if (GameProgress.level4Win)
            GameSceneManager.Instance.LoadScene("Level5");
    }

    // selected story. loads story screen
    public void onStory()
    {
        // load story text UI
        levelList.SetActive(false);
        storyOBJ.storyText.SetActive(true);
    }

    // go back to main menu
    public void onBack()
    {
        levelList.SetActive(false);
        mainMenuOBJ.mainMenu.SetActive(true);
    }

    //enables/disables buttons based on what levels have been beaten
    public void checkButton()
    {
        if (!GameProgress.level1Win)
            level2Button.interactable = false;
        else
            level2Button.interactable = true;

        if (!GameProgress.level2Win)
            level3Button.interactable = false;
        else
            level3Button.interactable = true;

        if (!GameProgress.level3Win)
            level4Button.interactable = false;
        else
            level4Button.interactable = true;

        if (!GameProgress.level4Win)
            level5Button.interactable = false;
        else
            level5Button.interactable = true;
    }
}
