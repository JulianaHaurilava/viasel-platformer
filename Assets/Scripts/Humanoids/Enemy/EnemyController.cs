using UnityEngine;

public class EnemyController : Mortal
{
    [SerializeField]
    private float moveSpeed = 3.0f;

    [SerializeField]
    private GameObject target;
    private Mortal _player;

    [SerializeField]
    private float triggerDistance;

    [SerializeField]
    private bool facingRight = true;
    private float _distance;

    protected override void Start()
    {
        base.Start();
        if (target.TryGetComponent(out Mortal mortal))
        {
            _player = mortal;
        }
    }

    protected override void Update()
    {
        base.Update();
        _distance = Vector3.Distance(transform.position, target.transform.position);

        if (_distance <= triggerDistance)
        {
            if (_distance <= AttackRange)
            {
                rb.velocity = new Vector2(0, 0);
                animator.SetBool("Run", false);
                if (_player.Health > 0)
                {
                    Attack();
                }
                return;
            }
            animator.SetBool("Run", true);
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        Vector2 direction = target.transform.position - transform.position;
        if (direction.x < 0 && facingRight)
        {
            Flip(-1);
        }
        else if (direction.x > 0 && !facingRight)
        {
            Flip(1);
        }
        rb.velocity = new Vector2(direction.normalized.x * moveSpeed, rb.velocity.y);
    }

    private void Flip(int k)
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(k * 2, 2, 2);
    }

    protected override void Die()
    {
        base.Die();
        enabled = false;
    }


}
