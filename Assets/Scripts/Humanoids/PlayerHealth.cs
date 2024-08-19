using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Image healthSlider;

    Animator anim;
    AudioSource playerAudio2;
    PlayerController playerController;
    bool isDead;

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
