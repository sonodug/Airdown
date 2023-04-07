using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Plane _plane;
    [SerializeField] private List<Transform> _shootPoints;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _money;

    private List<PlayerWeapon> _openedWeapons;
    
    private int _currentPlaneNumber = 0;
    private float _currentHealth;
    private float _timeAfterLastShoot;

    public UnityAction<float> MoneyChanged;
    public UnityAction<float, float> HealthChanged;
    public UnityAction<float> Damaged;
    public UnityAction NewWeaponPurchased;

    private void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        if (!PauseControl.GameIsPaused)
        {
            _timeAfterLastShoot += Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && (_timeAfterLastShoot >= _shootDelay))
            {
                _plane.Shoot(_shootPoints[0]);
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
        _plane.InstallWeapon(weapon);
    }

    public void GetReward(float reward)
    {
        _money += reward;
        MoneyChanged?.Invoke(_money);
    }
}
