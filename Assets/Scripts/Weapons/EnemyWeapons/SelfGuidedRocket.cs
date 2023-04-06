using System;
using UnityEngine;

public class SelfGuidedRocket : EnemyWeapon
{
    [Range(1.0f, 5.0f)]
    [SerializeField] private int _hitsToDestroy;
    
    [SerializeField] private float _rotationSpeed;

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
            _hitsToDestroy -= 1;
            Destroy(weapon.gameObject);
            
            if (_hitsToDestroy == 0)
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