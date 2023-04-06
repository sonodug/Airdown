using UnityEngine;

public class ERocket : EnemyWeapon
{
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
    }

    public override void MoveWeapon()
    {
        transform.Translate(Vector2.down * (Speed * Time.deltaTime));
    }
}