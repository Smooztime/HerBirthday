using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    //[SerializeField] GameObject roomEntrance;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerController>())
        {
            Debug.Log("flip");
            //flip ground room
            SoundManager.Instance.PlaySFX("FightRoom", 1f);
        }
    }
}
