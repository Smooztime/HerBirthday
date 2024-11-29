using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoses : MonoBehaviour
{
    [SerializeField] GameObject roses;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            Destroy(roses);
        }
    }
}
