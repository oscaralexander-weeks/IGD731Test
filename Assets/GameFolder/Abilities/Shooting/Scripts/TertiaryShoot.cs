using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TertiaryShoot : BaseDefaultWeapon
{
    public int pelletCount = 7;

    private void Start()
    {
        CooldownTimer = Cooldown;
    }

    private void Update()
    {

        if (IsOnCooldown)
        {
            CooldownTimer -= Time.deltaTime;

            if (CooldownTimer < 0.01f)
            {
                IsOnCooldown = false;
                CooldownTimer = Cooldown;
            }
        }
    }
    public override void Shoot()
    {
        if (IsOnCooldown || AbilityCount <= 0)
        {
            if (AbilityCount <= 0) Debug.LogWarning("No ammo left!");
            return;
        }

        OnFire?.Invoke();

        for (int i = 0; i < pelletCount; i++)
        {

            float currentAngle = Random.Range(15, 30);

            Quaternion pelletRotation = Firepoint.rotation * Quaternion.Euler(0f, currentAngle, 0f);

            GameObject pellet = Instantiate(ShotPrefab, Firepoint.position, pelletRotation);
            pellet.GetComponent<Rigidbody>().velocity = pellet.transform.forward * ShotSpeed;
            Destroy(pellet, 1);
        }

        IsOnCooldown = true;
        CooldownTimer = Cooldown;
        AbilityCount--;
    }
}
