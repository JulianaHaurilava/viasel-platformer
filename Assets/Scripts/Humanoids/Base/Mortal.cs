using UnityEngine;

public abstract class Mortal : Killer
{
    public float Health;
    [SerializeField]
    protected HealthBar healthBar;

    private float _maxHealth;

    protected override void Start()
    {
        base.Start();
        _maxHealth = Health;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(_maxHealth);
        }
    }

    public virtual void GetDamage(float damage)
    {
        animator.SetTrigger("Hurt");
        Health -= damage;
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(Health);
        }
        CheckIfDead();
    }

    public virtual void Heal(float healPoints)
    {
        Health = (Health + healPoints > _maxHealth) ? Health = _maxHealth : Health += healPoints;
        healthBar.UpdateHealthBar(Health);
    }

    protected virtual void Die()
    {
        animator.SetTrigger("Die");
        Invoke(nameof(EndGame), 1f);
    }

    private void EndGame()
    {
        ScenesManager.EndGame();
    }

    private void CheckIfDead()
    {
        if (Health <= 0)
        {
            Die();
        }
    }
}
