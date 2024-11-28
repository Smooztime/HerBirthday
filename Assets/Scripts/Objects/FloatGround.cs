using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatGround : MonoBehaviour,IFloatable
{
    [SerializeField] float floatingSpeed = 1f;
    [SerializeField] float floatingHeight = 2f;
    private float initialY;
    private float initialX;
    private void Start()
    {
        initialY = transform.localPosition.y;
        initialX = transform.localPosition.x;
    }
    public void Floating()
    {
        float newYPosition = initialY + Mathf.Sin(Time.time * floatingSpeed) * floatingHeight;
        transform.localPosition = new Vector3(transform.localPosition.x, newYPosition, transform.localPosition.z);
    }
    private void FixedUpdate()
    {
        Floating();
    }
}
