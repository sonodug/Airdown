using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private List<Plane> _aviation;
    [SerializeField] private List<Transform> _shootPoints;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _money;

    private Plane _currentPlane;
    private int _currentPlaneNumber = 0;
    private int _currentHealth;
    private float _timeAfterLastShoot;

    public UnityAction<float> MoneyChanged;

    private void Start()
    {
        _currentPlane = _aviation[0];
    }

    private void Update()
    {
        if (!PauseControl.GameIsPaused)
        {
            _timeAfterLastShoot += Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && (_timeAfterLastShoot >= _shootDelay))
            {
                _currentPlane.Shoot(_shootPoints[0]);
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
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    public void GetReward(float reward)
    {
        _money += reward;
        MoneyChanged?.Invoke(_money);
    }
}
