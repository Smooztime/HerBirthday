using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorPivot;
    public float rotationAngle = 90f;
    public float rotationDuration = 1f;

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private float rotationTime = 0f;
    private bool isOpened = false;

    [SerializeField] DoorTrigger trigger;
    void Start()
    {
        rotationTime = 0f;
        initialRotation = doorPivot.transform.rotation;
        targetRotation = Quaternion.Euler(0, rotationAngle, 0) * initialRotation;
    }

    private void OnEnable()
    {

        if (trigger != null)
        {
            trigger.doorTrigger.AddListener(OpenDoor);
            trigger.doorTriggerExit.AddListener(CloseDoor);
        }
    }

    private void OnDisable()
    {

        if (trigger != null)
        {
            trigger.doorTrigger.RemoveListener(OpenDoor);
            trigger.doorTriggerExit.RemoveListener(CloseDoor);
        }
    }
    public void OpenDoor()
    {
        Debug.Log("open door");
        if (!isRotating)
        {

            isRotating = true;
            rotationTime = 0f;
            SoundManager.Instance.PlaySFX("OpenDoor", 0.8f);
        }
    }
    private void CloseDoor()
    {
        if (!isRotating && isOpened)
        {

            isRotating = true;
            rotationTime = 0f;
            initialRotation = doorPivot.transform.rotation;
            targetRotation = Quaternion.Euler(0, 0, 0) * Quaternion.identity;
        }
    }
    void FixedUpdate()
    {

        if (isRotating)
        {
            rotationTime += Time.fixedDeltaTime / rotationDuration;
            doorPivot.transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, rotationTime);
            if (rotationTime >= 1f)
            {
                isRotating = false;
                isOpened = targetRotation == Quaternion.Euler(0, rotationAngle, 0);
            }
        }

    }
}
