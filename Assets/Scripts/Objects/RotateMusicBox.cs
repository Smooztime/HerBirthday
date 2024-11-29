using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMusicBox : MonoBehaviour
{

    [SerializeField] GameObject rotatePart;
    [SerializeField] float rotationSpeed;
    private void FixedUpdate()
    {
        rotatePart.transform.Rotate(0f, rotationSpeed * Time.fixedDeltaTime, 0f);
    }
}
