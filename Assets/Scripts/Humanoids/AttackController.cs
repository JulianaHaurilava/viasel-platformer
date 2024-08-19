using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Audio")]
    AudioSource playerAudio;

    [Header("Attack")]
    public float attackRange = 1f;
    public int attackDamage = 10;
    public Transform attackPoint;

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
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
