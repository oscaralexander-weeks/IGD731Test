using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseDefaultWeapon : AbilitiesSuperclass
{
    [Header("References")]
    public Transform Firepoint;
    public GameObject ShotPrefab;
    public GameObject WeaponPrefab;

    [Header("Counts")]
    public int Ammo;
    public float ShotSpeed, ShotDecay;

    [Header("Timers")]
    public bool IsShooting;

    public virtual void Shoot()
    {

    }

}
