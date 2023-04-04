using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Aircraft : Enemy
{
    [SerializeField] private float _health;
    [SerializeField] private List<Transform> _shootPoints;

    [Range(2.0f, 6.0f)]
    [SerializeField] private float _shootDelaySpread;
    [SerializeField] private EnemyWeapon _weapon;

    private float _timeAfterLastShoot;

    protected IMovable PlaneMovement;
    private Health _eventHealth;

    protected virtual void Awake()
    {
        InitBehaviours();
    }

    private void Start()
    {
        _shootDelaySpread = Random.Range(2, _shootDelaySpread);
        Movement.Move(Target);
    }

    private void OnEnable()
    {
        _eventHealth.Died += OnDied;
    }

    private void OnDisable()
    {
        _eventHealth.Died -= OnDied;
    }

    private void Shoot()
    {
        foreach (var t in _shootPoints)
        {
            Instantiate(_weapon, t.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        _timeAfterLastShoot += Time.deltaTime;

        if (_timeAfterLastShoot >= _shootDelaySpread)
        {
            Shoot();
            _timeAfterLastShoot = 0;
        }
    }

    protected override void InitBehaviours()
    {
        _eventHealth = new Health(new NormalDyingPolicy(), _health);

        Health = _eventHealth;
        Movement = PlaneMovement;
    }

    public override void Attacked(float damage)
    {
        Health.ApplyDamage(damage);
    }

    protected override void OnDied()
    {
        Target.GetReward(Reward);
        Died?.Invoke();
        gameObject.SetActive(false);
    }
}