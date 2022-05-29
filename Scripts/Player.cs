using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapon;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get;  private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        ChangeWeapon(_weapon[_currentWeaponNumber]);
        _currentWeapon = _weapon[0];
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _currentWeapon.Recharge();

        if(Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int reward)
    {
        Money += reward;
        MoneyChanged?.Invoke(Money);
    }

    public void Buy(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapon.Add(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapon.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapon[_currentWeaponNumber]);
    }

    public void PrevoiusWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapon.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapon[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
