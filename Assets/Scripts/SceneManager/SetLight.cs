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
            playerlight.transform.SetParent(player.transform);
            playerlight.transform.position = player.transform.position + new Vector3(0f, 3.5f, 4f);
            if (playerlight != null)
            {
                playerlight.enabled = true;
                playerlight.intensity = 120f; 
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
