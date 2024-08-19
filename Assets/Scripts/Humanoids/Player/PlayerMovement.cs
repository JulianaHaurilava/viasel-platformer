using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float speed = 10f;

    [Header("Jump")]
    [SerializeField]
    private float jumpForce = 500f;
    [SerializeField]
    private float airMultiplier;

    [Header("Ground Check")]
    [SerializeField]
    LayerMask whatIsGround;
    private bool _grounded = true;

    private Rigidbody2D _rb;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Controls running
    /// </summary>
    /// <param name="input"></param>
    public void Move(float input)
    {
        if (_grounded)
        {
            _rb.velocity = new Vector2(input * speed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(input * speed * airMultiplier, _rb.velocity.y);
        }

        if (input > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if (input < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        bool moving = input != 0;
        _animator.SetBool("Run", moving && _grounded);
    }

    /// <summary>
    /// Controlls jumping
    /// </summary>
    public void Jump()
    {
        if (_grounded)
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            SwitchGroundedState(false);
        }
    }

    #region Ground Collision Check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.layer & 1) << whatIsGround.value != 0)
        {
            SwitchGroundedState(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.layer & 1) << whatIsGround.value != 0)
        {
            SwitchGroundedState(false);
        }
    }
    #endregion

    private void SwitchGroundedState(bool state)
    {
        _grounded = state;
        _animator.SetBool("IsJumping", !state);
    }
}
