using UnityEngine;

public class PlayerController : Mortal
{
    [SerializeField]
    private BonusCollection bonusCollection;

    public int Level = 1;
    public int Points = 0;

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
            return;
        }
    }

    public override void Die()
    {
        base.Die();
        Invoke(nameof(EndGame), 1f);
    }
}
