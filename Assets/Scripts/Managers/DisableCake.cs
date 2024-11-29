using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCake : MonoBehaviour
{
    [SerializeField] GameObject tray;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            tray.SetActive(false);
        }
    }
}
