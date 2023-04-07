using UnityEngine;
using UnityEngine.Events;

public class Health : IDamageable
{
    public float Value { get; private set; }

    private float _maxValue;

    public event UnityAction Died;

    private IDyingPolicy _dyingPolicy;

    public Health(IDyingPolicy dyingPolicy, float value)
    {
        _dyingPolicy = dyingPolicy;
        Value = value;
        _maxValue = value;
    }

    public float ApplyDamage(float damage)
    {
        Value -= damage;

        if (Value < 0)
            Value = 0;
        
        if (_dyingPolicy.Died(Value))
        {
            Died?.Invoke();
        }

        return Value;
    }
}