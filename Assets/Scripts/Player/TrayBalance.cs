using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayBalance : MonoBehaviour
{
    [SerializeField] private BoxCollider trigger;

    private Cake _cake;

    public void TrayRotation(Transform player, float angle)
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }

    private void OnTriggerStay(Collider other)
    {
        _cake = other.GetComponent<Cake>();
        if (_cake != null)
        {
            Debug.Log("Caking" + _cake.IsCakeDrop);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _cake = other.GetComponent<Cake>();
        if (_cake != null)
        {
            _cake.CakeDrop();
        }
    }
}
