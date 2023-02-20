using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // variables and objects stated
    public static GameSceneManager Instance;
    public float uiLoadTime = 0.5f;
    private AsyncOperation asyncOperation;

    // done when script is loaded
    private void Awake()
    {
        // ensures that the manager does not get destroyed during gameplay
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        // in the case that the manager could not find itself present
        {
            Destroy(gameObject);
        }
    }

    // action to load a given scene
    public void LoadScene(string sceneName)
    {
        // time set, in case of integration from paused game
        Time.timeScale = 1f;
        StartCoroutine(LoadNewScene(sceneName));
    }

    // the instance to load a scene
    private IEnumerator LoadNewScene(string sceneName)
    {
        // case if scene fails to load
        yield return null;
        Time.timeScale = 0f; // game is paused

        // loading the scene
        yield return new WaitForSecondsRealtime(uiLoadTime);
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            yield return null;  // wait a frame
        }
    }
}
