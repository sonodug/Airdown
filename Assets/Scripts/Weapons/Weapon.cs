using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;
    [SerializeField] protected ParticleSystem ShootEffect;
    [SerializeField] protected ParticleSystem ExplosionEffect;

    public abstract void MoveWeapon();
}
