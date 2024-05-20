using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string ItemName;

    public Sprite Sprite;

    [SerializeField]
    protected InventoryManager inventoryManager;

    [SerializeField]
    protected Mortal player;
    [SerializeField]
    protected string targetTag;

    protected Slot slot;

    protected abstract void OnMouseDown();

    protected abstract void OnTriggerEnter2D(Collider2D other);
}
