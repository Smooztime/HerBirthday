using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    public UnityEvent doorTrigger;
    public UnityEvent doorTriggerExit;
    private bool canOpen = true;
    [SerializeField] int doorID = 0;
    public int DoorId()
    { return doorID; }
    private bool isActived = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!canOpen)
        {
            return;
        }
        if (canOpen && other.GetComponent<PlayerController>())
        {
            //progress bar in level
            MenuManager.Instance.activedRoom++;

            doorTrigger?.Invoke();
            Debug.Log("player enter room");
            if (doorID == 4)
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
