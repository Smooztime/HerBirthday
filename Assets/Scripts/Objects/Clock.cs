using UnityEngine;

public class ClockRotation : MonoBehaviour
{
    [SerializeField] private Transform clockHand;
    [SerializeField] private float rotationSpeed = 60f;

    private float currentAngle = 0f;
    private float initialAngle = 0f;
    public bool isRotating = false;

    private void Start()
    {
        initialAngle = clockHand.rotation.eulerAngles.z;
        currentAngle = initialAngle;
    }
    void FixedUpdate()
    {

        if (isRotating)
        {
            currentAngle += rotationSpeed * Time.fixedDeltaTime;

            if (currentAngle >= 360f)
            {
                currentAngle -= 360f;
            }


            clockHand.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        }
    }
    public void StartRotateClock()
    {
        if (!isRotating)
        {
            isRotating = true;
            SoundManager.Instance.PlaySFX("ClockRotate", 1f);
        }
    }
    public void StopRotateClock()
    {
        isRotating = false;
    }
}
