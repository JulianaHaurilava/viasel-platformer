using TMPro;

using UnityEngine;

public class BonusCollection : MonoBehaviour
{
    private int _bonusValue = 0;

    [SerializeField]
    private TMP_Text bonusText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bonus"))
        {
            _bonusValue++;
            bonusText.text = _bonusValue.ToString();

            if (other.TryGetComponent(out Animator animator))
            {
                animator.SetTrigger("Collect");
            }
        }
    }
}
