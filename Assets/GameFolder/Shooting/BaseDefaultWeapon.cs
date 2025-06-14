using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefaultWeapon : MonoBehaviour
{
    [Header("References")]
    public Transform Firepoint;
    public GameObject ShotPrefab;

    [Header("Stats")]
    public int Ammo;
    public float Cooldown, CooldownTimer, ShotSpeed, ShotDecay;
    public bool IsOnCooldown;
    

    public virtual void Shoot()
    {

    }

}
