using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    [SerializeField] float time;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(End());
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Menu");
    }
}
