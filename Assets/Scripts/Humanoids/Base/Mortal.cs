using UnityEngine;

public abstract class Mortal : Killer
{
    [Header("Health")]
    public float Health;

    [SerializeField] protected HealthBar healthBar;

    private float _maxHealth;

    protected override void Start()
    {
        base.Start();
        SetHealth();
    }

    /// <summary>
    /// Sets maxHealth and healthBar
    /// </summary>
    private void SetHealth()
    {
        _maxHealth = Health;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(_maxHealth);
        }
    }
    
    /// <summary>
    /// Calculates remaining health and updates health bar 
    /// </summary>
    /// <param name="damage"></param>
    public virtual void GetDamage(float damage)
    {
        Health -= damage;
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(Health);
        }
        CheckIfDead();
    }

    /// <summary>
    /// Processes death of a unit
    /// </summary>
    public virtual void Die()
    {
        Animator.SetTrigger("Die");
        DeactivateHumanoid();
    }

    /// <summary>
    /// Prevents any interaction with dead unit
    /// </summary>
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

    /// <summary>
    /// Sets audio and animator effects according to death check results
    /// </summary>
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
            Animator.SetTrigger("Hurt");
        }
    }
}
