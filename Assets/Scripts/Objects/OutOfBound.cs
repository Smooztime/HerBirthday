using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    private PlayerController player;
    private Collider[] colliders;
    private bool isRespawning = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() && isRespawning == false)
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            player.GetComponent<Collider>().enabled = false;
            colliders = player.GetComponentsInChildren<Collider>();
            foreach (var col in colliders)
            {
                col.enabled = false;
            }
            StartCoroutine(ReSpawn());
        }
        
    }

    private IEnumerator ReSpawn()
    {
        isRespawning = true;
        Debug.Log(isRespawning);
        if(player != null)
        {
            yield return new WaitForSeconds(3f);
            player.GetComponent<Collider>().enabled = true;
            foreach (var col in colliders)
            {
                col.enabled = true;
            }
            CheckPointManager.Instance.LoadCheckpoint();
        }
        isRespawning = false;
        player = null;
        Debug.Log(isRespawning);
    }
}
