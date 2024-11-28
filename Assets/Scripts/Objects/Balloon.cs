using UnityEngine;

public class Balloon : MonoBehaviour, IFloatable
{
    [SerializeField] float floatingSpeed = 1f;
    [SerializeField] float floatingHeight = 2f;
    private float initialY;
    private float initialX;
    bool isFloating = false;

    
    public bool isSpawned=false;

   
    private void Awake()
    {
        initialY = transform.localPosition.y;
        initialX =transform.localPosition.x;
        isFloating = false;
    }
   
    public void StopFloat()
    {
        isFloating = false;
    }
    public void StartFloat()
    {
        isFloating = true;
    }

    public void Floating()
    {
        float newYPosition = initialY + Mathf.Sin(Time.time * floatingSpeed) * floatingHeight;
        float newXPosition = initialX + Mathf.Sin(Time.time * floatingSpeed * 0.5f) * floatingHeight;
        transform.localPosition = new Vector3(newXPosition, newYPosition, transform.localPosition.z);
    }
    private void Update()
    {
        if (isFloating)
        {
            Floating();
        }

    }
    void FixedUpdate()
    {
        if (isSpawned)
        {
            this.transform.position += Vector3.up * Time.deltaTime * 2f;
        }

    }
}
