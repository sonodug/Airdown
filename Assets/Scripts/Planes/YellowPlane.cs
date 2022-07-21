using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlane : Plane
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Weapon, shootPoint.position, Quaternion.identity);
    }
}
