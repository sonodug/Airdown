using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Plane> _aviation;
    [SerializeField] private List<Transform> _shootPoints;

    private Plane _currentPlane;
    private int _currentPlaneNumber = 0;
    private int _currentHealth;

    private void Start()
    {
        _currentPlane = _aviation[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentPlane.Shoot(_shootPoints[0]);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void GetDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }
}
