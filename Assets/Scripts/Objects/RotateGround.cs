using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGround : MonoBehaviour
{
    [SerializeField] GameObject rotatePart;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxRotationAngle = 5f;

    private void FixedUpdate()
    {
        float rotation = Mathf.Sin(Time.time * rotationSpeed) * maxRotationAngle;
        rotatePart.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
