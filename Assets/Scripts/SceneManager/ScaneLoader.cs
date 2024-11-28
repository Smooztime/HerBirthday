using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] DoorTrigger trigger;
    private bool sceneLoaded4 =false;
    private bool sceneLoaded5 = false;
    public void LoadScene(string name)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }
    //private void OnEnable()
    //{

    //    if (trigger != null)
    //    {
    //        trigger.doorTrigger.AddListener(() =>LoadSceneAdditive(name));
    //    }
    //}

    //private void OnDisable()
    //{

    //    if (trigger != null)
    //    {
    //        trigger.doorTrigger.RemoveListener(() =>LoadSceneAdditive(name));
    //    }
    //}
    public void LoadSceneAdditive(string name)
    {
        if (!sceneLoaded4 && trigger != null )
        {
            if (trigger.DoorId() == 3)
            {
                Debug.Log("load scene");
                // name = "Room5";
                SceneManager.LoadScene(name, LoadSceneMode.Additive);
                sceneLoaded4 = true;
            }
        }
        else if (!sceneLoaded5 && trigger.DoorId() == 4)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Additive);
            sceneLoaded5 = true;
        }

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
