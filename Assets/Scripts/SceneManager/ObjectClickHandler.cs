using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectClickHandler : MonoBehaviour
{
    private Renderer objectRenderer; 
    private Color originalColor;

    [SerializeField] private GameObject clickedColor; 
    [SerializeField] private string targetScene; 

    private void Start()
    {

        objectRenderer = GetComponentInChildren<Renderer>();

        if (objectRenderer != null)
        { 
            objectRenderer.material.SetColor("_FaceColor", Color.white);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           
            if (Physics.Raycast(ray, out hit))
            {
               
                if (hit.collider.gameObject.GetComponent<ObjectClickHandler>())
                {
                    OnMousClicked();
                }
            }
        }
    }
    private void OnMousClicked()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.SetColor("_FaceColor", Color.red);
        }

        Invoke(nameof(LoadTargetScene), 0.5f); 
    }

    private void LoadTargetScene()
    {

        SceneManager.LoadScene(targetScene);
    }
}
