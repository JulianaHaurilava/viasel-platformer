using UnityEngine;

public class EnemyController : Mortal
{
    [SerializeField]
    private float moveSpeed = 3.0f;

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float triggerDistance;

    private bool _facingRight = true;
    private float _distance;

    protected override void Update()
    {
        base.Update();
        _distance = Vector3.Distance(transform.position, target.transform.position);

        if (_distance <= triggerDistance)
        {
            if (_distance <= AttackRange)
            {
                animator.SetBool("Run", false);
                Attack();
                return;
            }
            animator.SetBool("Run", true);
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        Vector2 direction = target.transform.position - transform.position;
        if (direction.x < 0 && _facingRight || direction.x > 0 && !_facingRight)
        {
            Flip();
        }
        rb.velocity = new Vector2(direction.normalized.x * moveSpeed, rb.velocity.y);
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
