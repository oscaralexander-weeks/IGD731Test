using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseDefaultWeapon : MonoBehaviour
{
    [Header("References")]
    public Transform Firepoint;
    public GameObject ShotPrefab;
    public string WeaponName;

    [Header("Counts")]
    public int Ammo;
    public float Cooldown, CooldownTimer, ShotSpeed, ShotDecay;

    [Header("Timers")]
    public bool IsOnCooldown;
    public bool IsShooting;

    public virtual void Shoot()
    {

    }

}
