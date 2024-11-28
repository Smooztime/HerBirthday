using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;

    private Vector2 _movement;
    private Rigidbody _rb;
    private float _rotate;
    private float _playerRotate;
    private float balancePos;
    private bool canControlRotate;
    private TrayBalance _balance;
    private CharacterController character;
    private GroundCheck _groundCheck;

    public Rigidbody RB => _rb;

    public float PlayerRotate => _playerRotate;
    public PlayerSO PlayerSO => playerSO;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        _groundCheck = GetComponent<GroundCheck>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _balance = GetComponentInChildren<TrayBalance>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        MovementHandler();
        RotateHandler();
        BalanceCakeHandler();
    }

    private void MovementHandler()
    {
        Vector3 moveDir = new Vector3(_movement.x, 0f, _movement.y);
        moveDir.Normalize();
        moveDir.y = 0f;
        
        transform.Translate(moveDir * playerSO.playerSpeed * Time.deltaTime);
    }

    private void RotateHandler()
    {
        if(canControlRotate)
        {
            if (_rotate < 0f)
                transform.Rotate(0f, -playerSO.RotateSpeed * Time.deltaTime, 0f);

            else if (_rotate > 0f)
                transform.Rotate(0f, playerSO.RotateSpeed * Time.deltaTime, 0f);
        }
    }

    public void MovementInput(Vector2 input)
    {
        _movement = input;
    }

    public void RotateInput(float value)
    {
        _rotate = value;
    }

    private void BalanceCakeHandler()
    {
        float angleZ = balancePos * 15f;
        _balance.TrayRotation(transform ,angleZ);
    }

    public void BalanceInput(Vector2 mouse)
    {
        balancePos = (mouse.x - (Screen.width / 2)) / (Screen.width / 2);
    }

    public void SetRotateControl(bool value)
    {
        canControlRotate = value;
    }
}
