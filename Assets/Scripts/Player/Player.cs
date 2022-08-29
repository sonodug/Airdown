using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Plane> _aviation;
    [SerializeField] private List<Transform> _shootPoints;
<<<<<<< HEAD
=======
    [SerializeField] private float _shootDelay;
>>>>>>> dev

    private Plane _currentPlane;
    private int _currentPlaneNumber = 0;
    private int _currentHealth;
<<<<<<< HEAD
=======
    private float _timeAfterLastShoot;

    public int Money { get; private set; }
>>>>>>> dev

    private void Start()
    {
        _currentPlane = _aviation[0];
    }

    private void Update()
    {
<<<<<<< HEAD
        if (Input.GetMouseButtonDown(0))
        {
            _currentPlane.Shoot(_shootPoints[0]);
=======
        _timeAfterLastShoot += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && (_timeAfterLastShoot >= _shootDelay))
        {
            //залочить ui?
            _currentPlane.Shoot(_shootPoints[0]);
            _timeAfterLastShoot = 0;
>>>>>>> dev
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
