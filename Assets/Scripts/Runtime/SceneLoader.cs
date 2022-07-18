using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName: sceneName);
    }


    public void LoadStartScene()
    {
        // FindObjectOfType<GameState>().ResetState();
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Start()
    {
        Cursor.visible = false;
    }
}
