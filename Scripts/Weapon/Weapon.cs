using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBought = false;
    [SerializeField] protected float Delay;

    [SerializeField] protected Bullet Bullet;

    protected float TimeAfterShoot;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBought => _isBought;


    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isBought = true;
    }
    
    public void Recharge()
    {
        TimeAfterShoot += Time.deltaTime;
    }
    
    public void BeginRecharge()
    {
        TimeAfterShoot = 0;
    }
}
