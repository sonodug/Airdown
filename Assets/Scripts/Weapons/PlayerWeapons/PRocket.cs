using UnityEngine;

public class PRocket : PlayerWeapon
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Attacked(Damage);
            Destroy(gameObject);
        }
    }

    public override void MoveWeapon()
    {
        transform.Translate(Vector2.up * (Speed * Time.deltaTime));
    }
}