using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefaultWeapon : MonoBehaviour
{
    [Header("References")]
    public Transform Firepoint;
    public GameObject ShotPrefab;

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
