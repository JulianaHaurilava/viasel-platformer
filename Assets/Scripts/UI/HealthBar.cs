using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maxHealth;

    [SerializeField]
    private Image fill;
    [SerializeField]
    private Gradient gradient;

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void UpdateHealthBar(float health)
    {
        float healthLeft = health / maxHealth;
        fill.fillAmount = healthLeft >= 0 ? healthLeft : 0;
        fill.color = gradient.Evaluate(healthLeft);
    }
}
