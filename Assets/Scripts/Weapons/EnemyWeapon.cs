using UnityEngine;

public abstract class EnemyWeapon : MonoBehaviour
{
    [SerializeField] protected float Damage;
    [SerializeField] protected float Speed;

    protected Player Target;
    
    private void Update()
    {
        MoveWeapon();
    }

    public abstract void MoveWeapon();

    public void InitTarget(Player target)
    {
        Target = target;
    }
}