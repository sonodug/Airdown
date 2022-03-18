using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _reward;
    [SerializeField] private ParticleSystem _explosionEffect;

    [SerializeField] private List<Transform> _shootPoints;

    [Range(2.0f, 6.0f)]
    [SerializeField] private float _shootDelaySpread;
    [SerializeField] private EnemyWeapon _weapon;

    private float _timeAfterLastShoot;

    private Player _target;

    public Player Target => _target;

    public event UnityAction<Enemy> Dying;
    public event UnityAction Died;

    private void Start()
    {
        _shootDelaySpread = Random.Range(2, _shootDelaySpread);
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Dying?.Invoke(this);
        Died?.Invoke();
    }

    private void Shoot()
    {
        for (int i = 0; i < _shootPoints.Count; i++)
        {
            Instantiate(_weapon, _shootPoints[i].position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.GetDamage(_damage);
        }

        if (collision.TryGetComponent<DestroyerObstacle>(out DestroyerObstacle destroyer))
        {
            Die();
        }
    }

    private void Update()
    {
        _timeAfterLastShoot += Time.deltaTime;

        if (_timeAfterLastShoot >= _shootDelaySpread)
        {
            Shoot();
            _timeAfterLastShoot = 0;
        }
    }
}
