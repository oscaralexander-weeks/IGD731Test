using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponsHandler : MonoBehaviour
{
    [Header("Weapons")]
    public List<BaseDefaultWeapon> Weapons = new List<BaseDefaultWeapon>();
    //[SerializeField] private List<Transform> abilitySpawns = new List<Transform>();
    //[SerializeField] private List<GameObject> abilityPrefabs = new List<GameObject>();


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
}
