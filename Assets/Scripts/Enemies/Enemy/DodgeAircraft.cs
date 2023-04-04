using UnityEngine;

[RequireComponent(typeof(TargetAvoidingMovement))]
public class DodgeAircraft : Aircraft
{
    protected override void Awake()
    {
        PlaneMovement = GetComponent<TargetAvoidingMovement>();
        InitBehaviours();
    }    
}