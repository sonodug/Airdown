using UnityEngine;
using Zenject;

public abstract class WeaponViewModel : MonoBehaviour
{
    [Inject] private Player _player;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed;
    [SerializeField] protected PlayerWeapon Weapon;

    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    
    public void Buy()
    {
        _isBuyed = true;
        _player.ApplyWeaponBuyOffer(Weapon);
    }
}