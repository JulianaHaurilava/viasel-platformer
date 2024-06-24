using UnityEngine;

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

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float input)
    {
        if (grounded)
        {
            rb.velocity = new Vector2(input * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(input * speed * airMultiplier, rb.velocity.y);
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
        animator.SetBool("Run", moving);
    }

    public void Jump()
    {
        if (grounded)
        {
            animator.SetBool("IsJumping", true);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.layer & 1) << whatIsGround.value != 0)
        {
            grounded = true;
            animator.SetBool("IsJumping", false);
        }
    }
}
