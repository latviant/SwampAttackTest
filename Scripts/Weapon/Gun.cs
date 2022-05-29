using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        if (TimeAfterShoot >= Delay)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            BeginRecharge();
        }
    }      
}
