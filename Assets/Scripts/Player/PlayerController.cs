using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;

    private Transform cam;
    private Vector2 _movement;
    private Vector2 _rotation;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        MovementHandler();
        LookAt();
    }

    private void MovementHandler()
    {
        Vector3 moveDir = cam.forward * _movement.y + cam.right * _movement.x;
        moveDir.Normalize();
        moveDir.y = 0f;

        rb.velocity = moveDir;
        rb.velocity *= playerSO.playerSpeed;
    }

    public void MovementInput(Vector2 input)
    {
        _movement = input;
    }

    private void LookAt()
    {
        _rotation.x = Mathf.Clamp(_rotation.x, -45f, 45f);
        transform.eulerAngles = new Vector3(transform.rotation.x, _rotation.y, transform.rotation.z);
        cam.localRotation = Quaternion.Euler(_rotation.x, 0, 0);
    }

    public void MousePosition(Vector2 mouse)
    {
        _rotation.x -= mouse.y * playerSO.sensitivity * Time.fixedDeltaTime;
        _rotation.y += mouse.x * playerSO.sensitivity * Time.fixedDeltaTime;
    }

    private void BalanceCakeHandler()
    {

    }

    public void BalanceCakeInput(float value)
    {

    }
}
