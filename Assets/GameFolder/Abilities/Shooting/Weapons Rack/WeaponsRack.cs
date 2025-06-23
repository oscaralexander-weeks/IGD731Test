using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsRack : MonoBehaviour
{
    public List<BaseDefaultWeapon> Weapons = new List<BaseDefaultWeapon>();

    public void SwitchWeapon(List<BaseDefaultWeapon> playerWeapons)
    {
        playerWeapons[0] = Weapons[0];
    }

}
