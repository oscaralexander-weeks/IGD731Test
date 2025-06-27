using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponsRack : MonoBehaviour
{
    public List<BaseDefaultWeapon> Weapons = new List<BaseDefaultWeapon>();
    [SerializeField] private IconPanelUIAbility weaponUI;

    public void SwitchWeapon(List<BaseDefaultWeapon> playerWeapons)
    {
        playerWeapons[0] = Weapons[0];
        playerWeapons[0].AbilityCount = playerWeapons[0].AbilityCountMax;
        if(weaponUI!= null)
        {
            weaponUI.Ability = playerWeapons[0];
        }

        if(weaponUI == null)
        {
            Debug.LogWarning("icon not assigned in inspector");
        }
    }

}
