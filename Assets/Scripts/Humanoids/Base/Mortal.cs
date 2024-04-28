using UnityEngine;

public abstract class Mortal : Killer
{
    [SerializeField]
    private float health;
    [SerializeField]
    private HealthBar healthBar;

    protected override void Start()
    {
        base.Start();
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(health);
        }
    }

    public virtual void GetDamage(float damage)
    {
        animator.SetTrigger("Hurt");
        health -= damage;
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health);
        }
        CheckIfDead();
    }
    protected virtual void Die()
    {
        animator.SetTrigger("Die");
        Invoke(nameof(EndGame), 3f);
    }

    private void EndGame()
    {
        ScenesManager.EndGame();
    }

    private void CheckIfDead()
    {
        if (health <= 0)
        {
            Die();
        }
    }
}
