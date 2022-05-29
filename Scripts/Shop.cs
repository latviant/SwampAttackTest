using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private GameObject _itemContainer;



    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i ++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon )
    {
        var view = Instantiate(_weaponView, _itemContainer.transform);
        view.SellButtonClick += OnBoughtButtonClick;
        view.Render(weapon);
    }

    private void OnBoughtButtonClick(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if(weapon.Price <= _player.Money)
        {
            _player.Buy(weapon);
            weapon.Buy();
            weaponView.SellButtonClick -= OnBoughtButtonClick;
        }
    }
} 
