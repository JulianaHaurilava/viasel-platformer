using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    AudioSource playerAudio;

    public float attackCooldown = 2f;  // ������������� ���� �����

    private Animator animator;  // ��������� �������� �����
    private bool isAttacking = false;  // ������� �� ���� � ������ ������
    private float attackTimer = 2f;  // ������ ��� ������������� ����
    private float nextAttackTime = 0f;

    public float moveSpeed = 3.0f; // �������� �������� �����
    private float attackRange = 2f; // ��������� ����� �����
    public int attackDamage = 10; // ����, ��������� ������ ��� �����
    public Transform attackPoint;
    public int health = 50; // ���������� �������� �����

    private Transform player; // ������ �� ������
    private Rigidbody2D rb; // ��������� Rigidbody2D �����
    private bool isFacingRight = true; // ����, ������������ ����������� �������� �����

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // �������� ������ �� ������
        rb = GetComponent<Rigidbody2D>(); // �������� ������ �� ��������� Rigidbody2D �����
    }

    void Update()
    {
        // ������������ ���������� ����� ������ � �������
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // ���� ����� ��������� � �������� ��������� ����� � ������ ������ ����� � ��������� �����
        if (distanceToPlayer <= attackRange && Time.time > nextAttackTime)
        {
            // ���������� ������ ��������� �����
            nextAttackTime = Time.time + attackCooldown;

            // ������� ������
            Attack();
        }

        // ���� ���� �� �������, �� �� �������� � ������
        if (!isAttacking && distanceToPlayer < 15f)
        {
            animator.SetBool("Run", true);
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        // ������������ ����������� � ������
        Vector2 direction = player.transform.position - transform.position;

        // ������������ ����� � ������� ������
        if (direction.x < 0 && isFacingRight || direction.x > 0 && !isFacingRight)
        {
            Flip();
        }

        // ������� ����� � ������
        rb.velocity = new Vector2(direction.normalized.x * moveSpeed, rb.velocity.y);
    }

    void Attack()
    {
        // ���������� ������ �����
        attackTimer = 0f;

        // ��������� �����
        animator.SetTrigger("Attack");

        // ��������� ������������ � ����������� ������
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }

        // ������������� ���������� isAttacking � true
        isAttacking = true;
    }

    void Flip()
    {
        // �������������� �����
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void TakeDamage(int damage)
    {
        playerAudio.Play();
        animator.SetTrigger("Hurt");
        // �������� ���� �� ����� ������
        health -= damage;
        if (health <= 0)
        {
            // ���� �������� ����� ������ ��� ����� ����, �� �������
            Die();
        }
    }

    void Die()
    {
        // ���������� ������ �����
        Destroy(gameObject);
    }
}
