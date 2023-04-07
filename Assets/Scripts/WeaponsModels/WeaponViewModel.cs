using UnityEngine;
using Zenject;

public abstract class WeaponViewModel : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed;
    [SerializeField] private PlayerWeapon _weapon;

    public PlayerWeapon Weapon => _weapon;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    
    public void DisableButton()
    {
        _isBuyed = true;
    }
}