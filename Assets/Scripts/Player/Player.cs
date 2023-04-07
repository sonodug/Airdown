using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Plane _plane;
    [SerializeField] private List<ShootPoint> _shootPoints;
    [SerializeField] private float _shootDelay;
    [SerializeField] private List<PlayerWeapon> _openedWeapons;
    
    private float _money;
    private int _currentPlaneNumber = 0;
    private float _currentHealth;
    private float _timeAfterLastShoot;

    private ShootPoint _currentShootPoint;
    private readonly WeaponConfigureVisitor _configureVisitor = new WeaponConfigureVisitor();

    public UnityAction<float> MoneyChanged;
    public UnityAction<float, float> HealthChanged;
    public UnityAction<float> Damaged;
    public UnityAction NewWeaponPurchased;

    private enum ShootPosition
    {
        Rocket = 0,
        ExplosionRocket = 0,
        DoubleRocket = 1,
        DoubleExplosionRocket = 1
    }
    
    private void Start()
    {
        _currentHealth = _health;
        _currentShootPoint = _shootPoints[(int)ShootPosition.DoubleRocket];
        _configureVisitor.Init(this);
    }

    private void Update()
    {
        if (!PauseControl.GameIsPaused)
        {
            _timeAfterLastShoot += Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && (_timeAfterLastShoot >= _shootDelay))
            {
                foreach (var pos in _currentShootPoint.Transforms)
                {
                    _plane.Shoot(pos);
                }
                
                _timeAfterLastShoot = 0;
            }
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void GetDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
        Damaged?.Invoke(damage);
        if (_currentHealth <= 0)
            Die();
    }

    public void ApplyWeaponBuyOffer(PlayerWeapon weapon)
    {
        NewWeaponPurchased?.Invoke();
        _openedWeapons.Add(weapon);
        _plane.InstallWeapon(weapon); //a
        weapon.Accept(_configureVisitor); //a
    }

    public void ConfigureByDoubleRocketWeapon()
    {
        _currentShootPoint = _shootPoints[(int)ShootPosition.DoubleRocket];
    }

    public void ConfigureByExplosionRocketWeapon()
    {
        _currentShootPoint = _shootPoints[(int)ShootPosition.ExplosionRocket];
    }
    
    public void ConfigureRocketWeapon()
    {
        _currentShootPoint = _shootPoints[(int)ShootPosition.Rocket];
    }

    public void DecreaseBalance(float price)
    {
        _money -= price;
        MoneyChanged?.Invoke(_money);
    }
    
    public void GetReward(float reward)
    {
        _money += reward;
        MoneyChanged?.Invoke(_money);
    }
}

[System.Serializable]
public class ShootPoint
{
    public List<Transform> Transforms;
}
