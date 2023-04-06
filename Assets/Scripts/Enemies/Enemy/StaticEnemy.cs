using UnityEngine;

[RequireComponent(typeof(PointMovement))]
public class StaticEnemy : Aircraft
{
    protected override void Awake()
    {
        PlaneMovement = GetComponent<PointMovement>();
        InitBehaviours();
    }  
} 