using System;
using TMPro;
using UnityEngine;
using Zenject;

public class MoneyController : MonoBehaviour
{
    [Inject] private Player _player;
    [SerializeField] private TMP_Text _moneyText;

    private float _moneyBank;

    public float MoneyBank => _moneyBank;

    private void OnEnable()
    {
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(float money)
    {
        _moneyBank = money;
        _moneyText.text = money.ToString();
    }
}
