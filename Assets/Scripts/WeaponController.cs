using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Segunda Arma 25 PUNTOS
// * Animacion por rotaci�n

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    AttackController[] weapons;

    AttackController _currentWeapon;

    int _selectedWeapon;

    private void Start()
    {
        _selectedWeapon = 0;
        SelectWeapon();
    }

    private void Update()
    {
        HandleScrollWheel();
        HandleAttack();
    }

    private void HandleScrollWheel()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0.0F)
        {
            _selectedWeapon = scrollWheel > 0.0F
                ? _selectedWeapon + 1
                : _selectedWeapon - 1;

            if (_selectedWeapon >= weapons.Length)
            {
                _selectedWeapon = 0;
            }
            else if (_selectedWeapon < 0)
            {
                _selectedWeapon = weapons.Length - 1;
            }
            SelectWeapon();
        }
    }

    public void HandleAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            _currentWeapon.Attack();
        }
    }


    private void SelectWeapon()
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            AttackController controller = weapons[i];
            bool isActive = (_selectedWeapon == i);
            controller.gameObject.SetActive(isActive);
        }
        _currentWeapon = weapons[_selectedWeapon];
    }
}
