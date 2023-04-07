using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private WeaponViewModel _weaponViewModel;
    public event UnityAction<WeaponViewModel, WeaponView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonCLick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonCLick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (_weaponViewModel.IsBuyed)
            _sellButton.interactable = false;
    }

    public void Render(WeaponViewModel weaponViewModel)
    {
        _weaponViewModel = weaponViewModel;
        _price.text = weaponViewModel.Price.ToString();
        _icon.sprite = weaponViewModel.Icon;
    }

    private void OnButtonCLick()
    {
        SellButtonClick?.Invoke(_weaponViewModel, this);
    }
}
