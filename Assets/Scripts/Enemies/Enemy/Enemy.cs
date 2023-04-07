using UnityEngine;
using UnityEngine.Events;
using Zenject;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected ParticleSystem DestroyEffect;
    [SerializeField] protected int Reward;

    [Inject] protected Player Target;
    
    public UnityAction Died;
    public UnityAction<float, float> HealthChanged;
    
    protected IDamageable Health;
    protected IMovable Movement;

    public void Init(Player target)
    {
        Target = target;
    }
    
    protected abstract void InitBehaviours();
    protected abstract void OnDied();
    public abstract void Attacked(float damage);
}
