using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Shop : MonoBehaviour
{
    [Inject] private Player _player;
    [SerializeField] private List<WeaponViewModel> _weaponViewModels = new List<WeaponViewModel> ();
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private MoneyController _moneyController;

    private void Start()
    {
        foreach (var plane in _weaponViewModels)
        {
            AddItem(plane);
        }
    }

    private void AddItem(WeaponViewModel weaponViewModel)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(weaponViewModel);
    }

    private void OnSellButtonClick(WeaponViewModel weaponViewModel, WeaponView view)
    {
        TrySellPlane(weaponViewModel, view);
    }

    private void TrySellPlane(WeaponViewModel weaponViewModel, WeaponView view)
    {
        if (weaponViewModel.Price <= _moneyController.MoneyBank)
        {
            weaponViewModel.DisableButton();
            _player.ApplyWeaponBuyOffer(weaponViewModel.Weapon);
            _player.DecreaseBalance(weaponViewModel.Price);
        }
    }
}
