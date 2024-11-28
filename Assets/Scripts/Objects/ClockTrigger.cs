using UnityEngine;

public class ClockTrigger : MonoBehaviour
{
    [SerializeField] private ClockRotation clock;
    void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerController>())
        {
            clock.StartRotateClock();

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<PlayerController>())
        {
            clock.StartRotateClock();
        }
    }
}
