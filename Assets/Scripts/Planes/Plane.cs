using UnityEngine;

public abstract class Plane : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed;
    [SerializeField] protected PlayerWeapon Weapon;

    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;

    public abstract void Shoot(Transform shootPoint);

    public void InstallWeapon(PlayerWeapon weapon)
    {
        Weapon = weapon;
        Debug.Log(Weapon);
    }
}