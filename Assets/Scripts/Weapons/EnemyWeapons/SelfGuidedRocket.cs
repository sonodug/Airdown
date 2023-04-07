using System;
using UnityEngine;
using UnityEngine.Events;

public class SelfGuidedRocket : EnemyWeapon
{
    [Range(1.0f, 5.0f)]
    [SerializeField] private int _hitsToDestroy;
    
    [SerializeField] private float _rotationSpeed;

    private int _currentHealth;

    public UnityAction<float, float> HealthChanged;

    private void Start()
    {
        _currentHealth = _hitsToDestroy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.GetDamage(Damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent<DestroyerObstacle>(out DestroyerObstacle obstacle))
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.TryGetComponent<PlayerWeapon>(out PlayerWeapon weapon))
        {
            _currentHealth -= 1;
            HealthChanged?.Invoke(_currentHealth, _hitsToDestroy);
            Destroy(weapon.gameObject);
            
            if (_currentHealth == 0)
                Destroy(gameObject);
        }
    }

    public override void MoveWeapon()
    {
        Vector3 targetPosition = Target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
        Vector3 targetDirection = targetPosition - transform.position;
        Debug.DrawRay(transform.position, targetDirection, Color.green);
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(90.0f + angle, Vector3.forward), Time.deltaTime * _rotationSpeed);
    }
}