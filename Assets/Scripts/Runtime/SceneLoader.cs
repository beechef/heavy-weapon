using System.Collections;
using System.Collections.Generic;
using Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField ]private IntVariable currentMission;

    public void LoadMission()
    {
        LoadBySceneName("Mission"+(currentMission.Value+1));
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadBySceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadStartScene()
    {
       
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

    public void QuitGamePlayScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}