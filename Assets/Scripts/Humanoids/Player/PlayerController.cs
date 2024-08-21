using UnityEngine;

public class PlayerController : Mortal
{
    [Header("Managers")]
    [SerializeField] private ScenesManager scenesManager;

    [HideInInspector] public int Level = 1;
    [HideInInspector] public int Points = 0;

    private BonusCollection _bonusCollection;

    protected override void Start()
    {
        base.Start();

        _bonusCollection = GetComponent<BonusCollection>();
        SetLevel();
    }

    public override void Die()
    {
        base.Die();
        Invoke(nameof(EndGame), 1f);
    }

    /// <summary>
    /// Sets level stats according to save files
    /// </summary>
    private void SetLevel()
    {
        PlayerData data = SaveSystem.LoadData();
        if (data != null)
        {
            Level = data.Level;
            Points = data.Points;
            _bonusCollection.UpdateBonuses(Points);

            Health = data.Health;
            healthBar.UpdateHealthBar(Health);
            return;
        }
    }

    /// <summary>
    /// Processes violent death of player
    /// </summary>
    private void EndGame()
    {
        scenesManager.EndLevel(EndResult.DEATH);
    }
}
