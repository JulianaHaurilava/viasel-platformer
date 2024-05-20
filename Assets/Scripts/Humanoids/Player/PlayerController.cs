using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Mortal
{
    [SerializeField]
    private InventoryManager inventoryManager;
    [SerializeField]
    private BonusCollection bonusCollection;

    public int Level = 1;
    public int Points = 0;

    public List<string> Items { get; set; } = new List<string>();

    protected override void Start()
    {
        base.Start();

        PlayerData data = SaveSystem.LoadData();
        if (data != null)
        {
            Level = data.Level;
            Points = data.Points;
            bonusCollection.UpdateBonuses(Points);

            Health = data.Health;
            healthBar.UpdateHealthBar(Health);

            foreach (var item in data.Items)
            {
                if (item == null)
                {
                    continue;
                }
                Items.Add(item);
                inventoryManager.SetItemFromFile(inventoryManager.CreateItem(item));
            }
            return;
        }

        Items = new();
        
    }
}
