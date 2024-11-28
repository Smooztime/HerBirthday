using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMusicBox : MonoBehaviour
{

    [SerializeField] GameObject rotatePart;
    [SerializeField] float rotationSpeed;
    [SerializeField] private Vector3 rotationDirection = Vector3.up;
    private void FixedUpdate()
    {
        rotatePart.transform.Rotate(rotationDirection *rotationSpeed * Time.fixedDeltaTime);
    }
}
