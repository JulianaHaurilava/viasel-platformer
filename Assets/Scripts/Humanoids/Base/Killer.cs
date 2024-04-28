using Unity.VisualScripting;
using UnityEngine;

public abstract class Killer : Humanoid
{
    [Header("Attack")]
    public float AttackRange = 1f;
    [SerializeField]
    private int attackDamage = 10;
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    protected float coolDownRate = 2;
    private bool _readyToAttack = true;
    private float _coolDownTime = 0;

    [SerializeField]
    private string targetTag;
    [SerializeField]
    private LayerMask targetLayer;

    protected virtual void Update()
    {
        if (_coolDownTime > 0)
        {
            _coolDownTime -= Time.deltaTime;
        }
        else
        {
            _readyToAttack = true;
        }
    }

    public void Attack()
    {
        if (_readyToAttack)
        {
            animator.SetTrigger("Attack");
            audioManager.Play("AttackSound");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, targetLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.CompareTag(targetTag))
                {
                    if (enemy.TryGetComponent(out Mortal mortal))
                    {
                        mortal.GetDamage(attackDamage);
                        ResetCoolDownRate();
                    }
                }
            }
        }
    }
    private void ResetCoolDownRate()
    {
        _coolDownTime = coolDownRate;
        _readyToAttack = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
    }
}
