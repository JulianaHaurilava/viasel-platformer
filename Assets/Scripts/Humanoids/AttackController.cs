using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Audio")]
    AudioSource playerAudio;

    [Header("Attack")]
    public float attackRange = 1f;
    public int attackDamage = 10;
    public Transform attackPoint;
    public LayerMask targetLayer;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    public void AttackEnemy()
    {
        animator.SetTrigger("Attack");
        playerAudio.Play();
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);

        //foreach (Collider2D enemy in hitEnemies)
        //{
        //    if (enemy.CompareTag("Enemy"))
        //    {
        //        enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
        //    }
        //}
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
