using UnityEngine;

public class DoubleRocketWeapon : PlayerWeapon
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Attacked(Damage);
            Destroy(gameObject);
        }
    }

    protected override void MoveWeapon()
    {
        transform.Translate(Vector2.up * (Speed * Time.deltaTime));
    }
    
    public override void Accept(IWeaponVisitor visitor)
    {
        visitor.Visit(this);
    }
}