<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private ParticleSystem _explosionEffect;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
=======
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;
    [SerializeField] protected ParticleSystem ShootEffect;
    [SerializeField] protected ParticleSystem ExplosionEffect;

    public abstract void MoveWeapon();
>>>>>>> dev
}
