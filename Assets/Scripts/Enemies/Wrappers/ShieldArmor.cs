public class ShieldArmor : IDamageable
{
    private IDamageable _damageable;
    private float _shieldEndurance;

    public ShieldArmor(IDamageable damageable, float shieldEndurance)
    {
        _damageable = damageable;
        _shieldEndurance = shieldEndurance;
    }

    public float ApplyDamage(float damage)
    {
        _shieldEndurance -= damage;

        if (_shieldEndurance <= 0)
            _damageable.ApplyDamage(damage);

        return _shieldEndurance;
    }
}