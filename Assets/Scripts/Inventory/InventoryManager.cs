using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField]
    private List<Item> items;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private List<Slot> slots;

    public void SetItem(Item item)
    {
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(item);
                playerController.Items.Add(item.ItemName);
                break;
            }
        }
    }

    public void SetItemFromFile(Item item)
    {
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(item);
                break;
            }
        }
    }

    public void RemoveItem()
    {

    }

    public Item CreateItem(string name)
    {
        switch (name)
        {
            case "Beer":
                return items[0];  
            default:
                return null;
        }
    }
}
