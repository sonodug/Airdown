<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
=======
>>>>>>> dev
using UnityEngine;

public abstract class Plane : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Sprite _spriteRenderer;
    [SerializeField] private int _shopPrice;
    [SerializeField] private Sprite _shopIcon;
    [SerializeField] private bool _isBuyed;

    [SerializeField] protected Weapon Weapon;
=======
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed;

    [SerializeField] protected PlayerWeapon Weapon;

    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
>>>>>>> dev

    public abstract void Shoot(Transform shootPoint);
    public void Buy()
    {
        _isBuyed = true;
    }
}
