using UnityEngine;

public class BalloonTrigger : MonoBehaviour
{
    private Balloon balloon;
    GameObject balloons;
    private void Start()
    {
        balloons = GameObject.Find("Balloons");
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerController>())
        {
            if (balloons != null)
            {
                Balloon[] balloon = balloons.GetComponentsInChildren<Balloon>();
                foreach (Balloon balloonObject in balloon)

                    if (balloonObject != null)
                    {
                        balloonObject.StartFloat();
                    }
            }

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<PlayerController>())
        {
            if (balloons != null)
            {
                Balloon[] balloon = balloons.GetComponentsInChildren<Balloon>();
                foreach (Balloon balloonObject in balloon)

                    if (balloonObject != null)
                    {
                        balloonObject.StopFloat();
                    }
            }

        }
    }
}

