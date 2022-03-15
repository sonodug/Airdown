using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private ParticleSystem _explosionEffect;

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.GetDamage(_damage);
            Destroy(gameObject);
        }
    }
}