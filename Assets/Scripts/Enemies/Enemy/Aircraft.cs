using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Aircraft : Enemy
{
    [SerializeField] private float _health;
    [SerializeField] private List<Transform> _shootPoints;

    [Range(2.0f, 6.0f)]
    [SerializeField] private float _shootDelaySpread;
    [SerializeField] protected EnemyWeapon Weapon;

    private float _timeAfterLastShoot;
    private Health _eventHealth;
    private SpriteRenderer _renderer;

    protected IMovable PlaneMovement;
    protected bool IsReadyToShoot;

    protected virtual void Awake()
    {
        InitBehaviours();
    }

    protected virtual void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _shootDelaySpread = Random.Range(2, _shootDelaySpread);
        Movement.Move(Target);
        Movement.Move();
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
            EnemyWeapon weapon = Instantiate(Weapon, t.position, Quaternion.identity);
            weapon.InitTarget(Target);
        }
    }

    private void Update()
    {
        CheckInCameraView();
        
        _timeAfterLastShoot += Time.deltaTime;

        if (_timeAfterLastShoot >= _shootDelaySpread && IsReadyToShoot)
        {
            Shoot();
            _timeAfterLastShoot = 0;
        }
    }

    private void CheckInCameraView()
    {
        IsReadyToShoot = _renderer.isVisible;
    }

    protected override void InitBehaviours()
    {
        _eventHealth = new Health(new NormalDyingPolicy(), _health);

        Health = _eventHealth;
        Movement = PlaneMovement;
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
    }
}