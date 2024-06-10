using UnityEngine;

public abstract class Killer : Humanoid
{
    [Header("Attack")]
    public float AttackRange = 1f;
    [SerializeField]
    private int attackDamage = 10;

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
            ResetCoolDownRate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            Transform parent = collision.transform.parent;
            if (parent.TryGetComponent(out Mortal mortal))
            {
                mortal.GetDamage(attackDamage);
            }
        }
    }

    private void ResetCoolDownRate()
    {
        _coolDownTime = coolDownRate;
        _readyToAttack = false;
    }
}
