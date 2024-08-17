using UnityEngine;

public abstract class Mortal : Killer
{
    public float Health;
    [SerializeField]
    protected HealthBar healthBar;
    [SerializeField]
    private ScenesManager manager;

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

    public virtual void Die()
    {
        animator.SetTrigger("Die");
        DeactivateHumanoid();
    }

    protected void DeactivateHumanoid()
    {
        Transform colliders = transform.Find("Colliders");
        colliders.gameObject.SetActive(false);
        Transform attackColliders = transform.Find("AttackZone");
        attackColliders.gameObject.SetActive(false);

        if (TryGetComponent(out Rigidbody2D rb))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    protected void EndGame()
    {
        manager.EndLevel(EndResult.DEATH);
    }
    private void CheckIfDead()
    {
        if (Health <= 0)
        {
            audioManager.Play("Lethal");
            Die();
        }
        else
        {
            audioManager.Play("NonLethal");
            animator.SetTrigger("Hurt");
        }
    }
}
