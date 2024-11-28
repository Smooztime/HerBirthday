using UnityEngine;

public class Cake : MonoBehaviour
{

    private PlayerController player;
    private Rigidbody rb;
    private bool _isCakeDrop;
    public Vector3 dropPosition;
    public void ResetRigidbody()
    {
        rb.velocity = Vector3.zero;
    }

    public bool IsCakeDrop
    {
        get => _isCakeDrop;
        set => _isCakeDrop = value;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
        
    }

    private void Update()
    {
        if ((!_isCakeDrop))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
        }
    }

    public void CakeDrop()
    {
        _isCakeDrop = true;
        transform.parent = null;
        transform.position = transform.localPosition;
        
        Debug.Log("Drop the cake!");

        //add checkPoint
        CheckPointManager.Instance.LoadCheckpoint();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("GroundMovement"))
        {
            Debug.Log("Lose! You can not bring your cake to your wife anymore");
        }
    }
}
