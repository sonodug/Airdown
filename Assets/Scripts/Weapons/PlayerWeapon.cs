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

    public abstract void MoveWeapon();
}
