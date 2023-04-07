using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerWeapon : MonoBehaviour
{
    [SerializeField] protected float Damage;
    [SerializeField] protected float Speed;
    
    private void Update()
    {
        MoveWeapon();
    }

    protected abstract void MoveWeapon();
    protected abstract void OnTriggerEnter2D(Collider2D collision);
    public abstract void Accept(IWeaponVisitor visitor);
}
