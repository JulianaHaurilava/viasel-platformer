using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;            // начальное здоровье игрока
    public int currentHealth;                   // текущее здоровье игрока
    public Image healthSlider;                 // полоска здоровья

    Animator anim;                              // ссылка на аниматор
    AudioSource playerAudio2;                    // ссылка на аудио источник
    PlayerController playerController;              // ссылка на скрипт движения игрока
    bool isDead;                                // мертв ли игрок

    void Awake()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        playerAudio2 = audioSources[1];
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
        playerAudio2.Play();
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        // устанавливаем флаг смерти
        isDead = true;

        // отключаем скрипт движения игрока
        playerController.enabled = false;

        // запускаем анимацию смерти
        anim.SetBool("Death", true);
    }
}
