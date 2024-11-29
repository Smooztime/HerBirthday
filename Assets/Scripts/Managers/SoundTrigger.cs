using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("player enter");
           
            SoundManager.Instance.PlaySFX("GiftBox", 1f);
        }
    }
}
