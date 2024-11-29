using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCake : MonoBehaviour
{
    [SerializeField] GameObject tray;
    [SerializeField] StuffsDisappear StuffsDisappear;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            tray.SetActive(false);
            StartCoroutine(StuffsDisappear.ActiveDisappear());
            SoundManager.Instance.StopBGM("Nandini");
            SoundManager.Instance.PlayBGM("HBD", 0.5f);
        }
    }
}
