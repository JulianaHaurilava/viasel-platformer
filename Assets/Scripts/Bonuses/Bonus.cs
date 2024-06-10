using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Bonus : MonoBehaviour
{
    [SerializeField]
    private int bonusValue = 1;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TryGetComponent(out Collider2D collider);
            collider.enabled = false;

            Transform player = other.transform.parent;
            if (player.TryGetComponent(out BonusCollection bc))
            {
                bc.UpdateBonuses(bonusValue);
                bc.SaveBonusData(bonusValue);
            }
            _animator.SetTrigger("Collect");
        }
    }
    public void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
