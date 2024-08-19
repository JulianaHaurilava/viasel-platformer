using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    #region Const
    private const string HORIZONTAL_AXIS = "Horizontal";
    #endregion

    [HideInInspector] public bool CanMove = true;

    private float _input;
    private PlayerMovement _playerMovement;
    private Killer _playerController;

    [Header("Keybinds")]
    [SerializeField]
    KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    KeyCode attackKey = KeyCode.Mouse0;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerController = GetComponent<Killer>();
    }

    void Update()
    {
        ControlPlayer();
    }

    /// <summary>
    /// Processes user input to move player
    /// </summary>
    private void ControlPlayer()
    {
        if (!CanMove)
        {
            _input = 0;
        }
        else
        {
            _input = Input.GetAxisRaw(HORIZONTAL_AXIS);

            if (Input.GetKeyDown(jumpKey))
            {
                _playerMovement.Jump();
            }
            if (Input.GetKeyDown(attackKey))
            {
                _playerController.Attack();
            }
        }
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_input);
    }
}
