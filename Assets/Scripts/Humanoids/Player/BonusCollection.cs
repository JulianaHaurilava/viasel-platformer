using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class BonusCollection : MonoBehaviour
{
    private PlayerController _playerController;

    private int _bonusValue = 0;

    [SerializeField]
    private TMP_Text bonusText;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public void UpdateBonuses(int bonuses)
    {
        _bonusValue += bonuses;
        bonusText.text = _bonusValue.ToString();
    }

    public void SaveBonusData(int bonuses)
    {
        _playerController.Points += bonuses;
    }
}
