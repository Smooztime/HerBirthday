using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] DoorTrigger trigger;
    public void LoadScene(string name)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }
    private void OnEnable()
    {

        if (trigger != null)
        {
            trigger.doorTrigger.AddListener(() =>LoadSceneAdditive(name));
          
        }
    }

    private void OnDisable()
    {

        if (trigger != null)
        {
            trigger.doorTrigger.RemoveListener(() => LoadSceneAdditive(name));
         
        }
    }
    public void LoadSceneAdditive(string name)
    {
        Debug.Log("Load scene");
        name = "LastLevel";
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

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
