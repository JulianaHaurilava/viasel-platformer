using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";

    private float input;

    private PlayerMovement _playerMovement;
    private Killer _killer;

    [Header("Keybinds")]
    [SerializeField]
    KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    KeyCode attackKey = KeyCode.Mouse0;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _killer = GetComponent<Killer>();
    }

    void Update()
    {
        input = Input.GetAxisRaw(HORIZONTAL_AXIS);

        if (Input.GetKeyDown(jumpKey))
        {
            _playerMovement.Jump();
        }
        if (Input.GetKeyDown(attackKey))
        {
            _killer.Attack();
        }
    }
    private void FixedUpdate()
    {
        _playerMovement.Move(input);
    }
}
