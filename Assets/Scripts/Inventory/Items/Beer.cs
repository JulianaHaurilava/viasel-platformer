using UnityEngine;

public class Beer : Item
{
    [SerializeField]
    private float healPoints;

    protected override void OnMouseDown()
    {
        player.Heal(healPoints);
        slot.RemoveItem();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            inventoryManager.SetItem(this);
        }
    }
}
