using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    AudioSource playerAudio;

    public float attackCooldown = 2f;  // периодичность атак врага

    private Animator animator;  // компонент анимации врага
    private bool isAttacking = false;  // атакует ли враг в данный момент
    private float attackTimer = 2f;  // таймер дл€ периодичности атак
    private float nextAttackTime = 0f;

    public float moveSpeed = 3.0f; // скорость движени€ врага
    private float attackRange = 2f; // дистанци€ атаки врага
    public int attackDamage = 10; // урон, наносимый врагом при атаке
    public Transform attackPoint;
    public int health = 50; // количество здоровь€ врага

    private Transform player; // ссылка на игрока
    private Rigidbody2D rb; // компонент Rigidbody2D врага
    private bool isFacingRight = true; // флаг, определ€ющий направление движени€ врага

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // получаем ссылку на игрока
        rb = GetComponent<Rigidbody2D>(); // получаем ссылку на компонент Rigidbody2D врага
    }

    void Update()
    {
        // –ассчитываем рассто€ние между врагом и игроком
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // ≈сли игрок находитс€ в пределах дистанции атаки и прошло нужное врем€ с последней атаки
        if (distanceToPlayer <= attackRange && Time.time > nextAttackTime)
        {
            // —брасываем таймер следующей атаки
            nextAttackTime = Time.time + attackCooldown;

            // јтакуем игрока
            Attack();
        }

        // ≈сли враг не атакует, то он движетс€ к игроку
        if (!isAttacking && distanceToPlayer < 15f)
        {
            animator.SetBool("Run", true);
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        // –ассчитываем направление к игроку
        Vector2 direction = player.transform.position - transform.position;

        // ѕоворачиваем врага в сторону игрока
        if (direction.x < 0 && isFacingRight || direction.x > 0 && !isFacingRight)
        {
            Flip();
        }

        // ƒвигаем врага к игроку
        rb.velocity = new Vector2(direction.normalized.x * moveSpeed, rb.velocity.y);
    }

    void Attack()
    {
        // —брасываем таймер атаки
        attackTimer = 0f;

        // ¬ыполн€ем атаку
        animator.SetTrigger("Attack");

        // ѕровер€ем столкновение с коллайдером игрока
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }

        // ”станавливаем переменную isAttacking в true
        isAttacking = true;
    }

    void Flip()
    {
        // ѕереворачиваем врага
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void TakeDamage(int damage)
    {
        playerAudio.Play();
        animator.SetTrigger("Hurt");
        // получаем урон от атаки игрока
        health -= damage;
        if (health <= 0)
        {
            // если здоровье врага меньше или равно нулю, то умираем
            Die();
        }
    }

    void Die()
    {
        // уничтожаем объект врага
        Destroy(gameObject);
    }
}
