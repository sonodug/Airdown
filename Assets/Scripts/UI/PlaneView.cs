using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PlaneView : MonoBehaviour
{
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Plane _plane;
    public event UnityAction<Plane, PlaneView> SellButtonClick;

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
        if (_plane.IsBuyed)
            _sellButton.interactable = false; //вместе этого бы удалить нахуй это окно после закрытия
    }

    public void Render(Plane plane)
    {
        _plane = plane;
        _price.text = plane.Price.ToString();
        _icon.sprite = plane.Icon;
    }

    private void OnButtonCLick()
    {
        SellButtonClick?.Invoke(_plane, this);
    }
}
