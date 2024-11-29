using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    [SerializeField] float time;
    void Start()
    {
        StartCoroutine(End());
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Menu");
    }
}
