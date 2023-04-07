using System;
using UnityEngine;

[RequireComponent(typeof(KamikazeMovement))]
public class KamikazeAircraft : Enemy
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    private IMovable _movement;
    private Health _eventHealth;

    private void Awake()
    {
        _movement = GetComponent<KamikazeMovement>();
        InitBehaviours();
    }

    private void Update()
    {
        _movement.Move(Target);
    }

    private void OnEnable()
    {
        _eventHealth.Died += OnDied;
    }

    private void OnDisable()
    {
        _eventHealth.Died -= OnDied;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.GetDamage(_damage);
            Health.ApplyDamage(_health);
        }
    }

    protected override void InitBehaviours()
    {
        _eventHealth = new Health(new NormalDyingPolicy(), _health);
        Health = _eventHealth;
        Movement = _movement;
    }

    public override void Attacked(float damage)
    {
        HealthChanged?.Invoke(Health.ApplyDamage(damage), _health);
    }

    protected override void OnDied()
    {
        Target.GetReward(Reward);
        Died?.Invoke();
        gameObject.SetActive(false);
        //explosion
    }
}