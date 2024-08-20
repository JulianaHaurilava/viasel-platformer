using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class BonusCollection : MonoBehaviour
{
    [SerializeField] private TMP_Text bonusText;

    private PlayerController _playerController;
    private int _bonusValue = 0;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    /// <summary>
    /// Updates bonus text value
    /// </summary>
    /// <param name="bonuses"></param>
    public void UpdateBonuses(int bonuses)
    {
        _bonusValue += bonuses;
        bonusText.text = _bonusValue.ToString();
    }

    /// <summary>
    /// Updates global player points
    /// </summary>
    /// <param name="bonuses"></param>
    public void SaveBonusData(int bonuses)
    {
        _playerController.Points += bonuses;
    }
}
