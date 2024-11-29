using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLight : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] private Light playerlight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("player get light");
            playerlight.transform.SetParent(other.transform);
            if (playerlight != null)
            {
                playerlight.enabled = true;
                playerlight.intensity = 2.0f; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
    
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("Player exited the trigger and lost the light");


            transform.SetParent(null);

            if (playerlight != null)
            {
                playerlight.enabled = false;
            }
        }
    }
}
