using UnityEngine;

public class EnemyWeapon : Weapon
{
    private void Update()
    {
        MoveWeapon();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.GetDamage(Damage);
            Destroy(gameObject);
        }
    }

    public override void MoveWeapon()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }
}