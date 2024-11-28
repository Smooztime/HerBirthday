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
            //load another room
            doorTrigger?.Invoke();
            Debug.Log("player enter room");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<PlayerController>())
        {
            //load another room
            doorTriggerExit?.Invoke();
            canOpen = false;
        }
    }
}
