using UnityEngine;
using UnityEngine.Events;
using Zenject;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected ParticleSystem DestroyEffect;
    [SerializeField] protected int Reward;

    [Inject] protected Player Target;
    public UnityAction Died;
    
    protected IDamageable Health;
    protected IMovable Movement;

    public void Init(Player target)
    {
        Target = target;
    }
    
    protected abstract void InitBehaviours();
    public abstract void Attacked(float damage);
    protected abstract void OnDied();
}
