using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class WeaponsHandler : MonoBehaviour
{
    [Header("Weapons")]
    public List<BaseDefaultWeapon> Weapons = new List<BaseDefaultWeapon>();

    //public UnityEvent onWeaponSwitch;
    public bool IsInRangeToSwitchWeapon;
    public WeaponsRack WeaponsRack = null;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot(0);
        }
    }

    public void OnShoot2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot(1);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("press");
            if (IsInRangeToSwitchWeapon && WeaponsRack != null)
            {
                WeaponsRack.SwitchWeapon(Weapons);
            }
        }
    }

    public void Shoot(int index)
    {
        if(Weapons.Count > 0 && index <= Weapons.Count)
        {
            Weapons[index].Shoot();
        }
        else
        {
            Debug.LogWarning($"Weapon at index {index} is not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        WeaponsRack = other.GetComponent<WeaponsRack>();

        if(Weapons != null)
        {
            IsInRangeToSwitchWeapon = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        WeaponsRack = other.GetComponent<WeaponsRack>();

        if (Weapons != null)
        {
            IsInRangeToSwitchWeapon = false;
        }
    }
}
