using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class UZI : Weapon
{
    [SerializeField] private float timeDelay;
    [SerializeField] private int _numberBulletOfSalvo;
    [SerializeField] private int _timeDelayofSalvo;

    public override void Shoot(Transform shootPoint)
    {
        if (TimeAfterShoot >= Delay)
        {
            for(int i = 0; i < _numberBulletOfSalvo; i ++)
            {
                Instantiate(Bullet, shootPoint.position, Quaternion.identity);
                Thread.Sleep(10);
            }
          
            BeginRecharge();
        }
    }
}
