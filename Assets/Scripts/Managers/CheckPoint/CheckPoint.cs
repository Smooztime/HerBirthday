using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerController>())
        {

            CheckPointManager.Instance.SaveCheckpoint(this.transform.position);
        }
    }
}
