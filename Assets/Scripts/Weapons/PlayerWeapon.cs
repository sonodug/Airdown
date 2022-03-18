using UnityEngine;

public class PlayerWeapon : Weapon
{
    private void Update()
    {
        MoveWeapon();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
    public override void MoveWeapon()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
}
