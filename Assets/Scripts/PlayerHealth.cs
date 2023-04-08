using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;            // ��������� �������� ������
    public int currentHealth;                   // ������� �������� ������
    public Image healthSlider;                 // ������� ��������

    Animator anim;                              // ������ �� ��������
    AudioSource playerAudio;                    // ������ �� ����� ��������
    PlayerController playerController;              // ������ �� ������ �������� ������
    bool isDead;                                // ����� �� �����

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;
        healthSlider.fillAmount = 100;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.fillAmount = currentHealth / 100f;
        anim.SetBool("Hurt", true);
        //playerAudio.Play();
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        // ������������� ���� ������
        isDead = true;

        // ��������� ������ �������� ������
        playerController.enabled = false;

        // ��������� �������� ������
        anim.SetBool("Death", true);

        // ����������� ���� ������
        //playerAudio.Play();
    }
}
