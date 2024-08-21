using UnityEngine;

public abstract class Killer : Humanoid
{
    [Header("Target")]
    [SerializeField] private string targetTag;

    [Header("Attack")]
    [SerializeField] private int attackDamage = 1;
    [SerializeField] protected float coolDownRate = 2;

    public float AttackRange = 1f;

    private bool _readyToAttack = true;
    private float _coolDownTime = 0;

    protected virtual void Update()
    {
        CheckAttack();
    }

    /// <summary>
    /// Attacks if unit is ready
    /// </summary>
    public void Attack()
    {
        if (_readyToAttack)
        {
            Animator.SetTrigger("Attack");
            audioManager.Play("Miss");
            ResetCoolDownRate();
        }
    }

    /// <summary>
    /// Damages enemy if collides
    /// </summary>
    /// <param name="collision"></param>
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

    /// <summary>
    /// Checks if unit can attack and switches the attack status
    /// </summary>
    private void CheckAttack()
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

    /// <summary>
    /// Resets weapons cool down rate
    /// </summary>
    private void ResetCoolDownRate()
    {
        _coolDownTime = coolDownRate;
        _readyToAttack = false;
    }
}
