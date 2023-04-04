using UnityEngine;

[RequireComponent(typeof(TargetMovement))]
public class BasicAircraft : Aircraft
{
    protected override void Awake()
    {
        PlaneMovement = GetComponent<TargetMovement>();
        InitBehaviours();
    } 
}