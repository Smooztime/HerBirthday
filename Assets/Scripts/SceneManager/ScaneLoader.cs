using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(string name)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }

    //public void LoadSceneAdditive(string name)
    //{
    //    SceneManager.LoadScene(name,LoadSceneMode.Additive);
    //}

    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
