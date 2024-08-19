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
    private bool grounded = true;

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
        if (grounded)
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
        _animator.SetBool("Run", moving);
    }

    /// <summary>
    /// Controlls jumping
    /// </summary>
    public void Jump()
    {
        if (grounded)
        {
            _animator.SetBool("IsJumping", true);
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            grounded = false;
        }
    }

    /// <summary>
    /// Processes ground collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.layer & 1) << whatIsGround.value != 0)
        {
            grounded = true;
            _animator.SetBool("IsJumping", false);
        }
    }
}
