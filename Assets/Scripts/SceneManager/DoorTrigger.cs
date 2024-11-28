using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    public UnityEvent doorTrigger;
    public UnityEvent doorTriggerExit;
    private bool canOpen =true;
    [SerializeField] int doorID = 0;
    public int DoorId()
    { return doorID; }

private void OnTriggerEnter(Collider other)
    {
        if (canOpen && !other.GetComponent<PlayerController>())
        {
            doorTrigger?.Invoke();
            Debug.Log("player enter room");
            if (doorID ==4)
            {
                SoundManager.Instance.PlaySFX("Fight", 1f);
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<PlayerController>())
        {
            doorTriggerExit?.Invoke();
            canOpen = false;
        }
    }
}
