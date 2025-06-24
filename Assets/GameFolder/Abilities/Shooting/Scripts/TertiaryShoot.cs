using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TertiaryShoot : BaseDefaultWeapon
{
    [Header("Spread Settings")]
    [Tooltip("Number of pellets per shot")]
    public int pelletCount = 7;
    [Tooltip("Angle in degrees of the total spread cone")]
    public float spreadAngle = 30f;

    public float shotSpeed = 20f;

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

        // Starting offset so that pellets fan evenly around the forward vector
        float halfSpread = spreadAngle * 0.5f;
        for (int i = 0; i < pelletCount; i++)
        {
            // Evenly distribute angle between [-halfSpread .. +halfSpread]
            float t = (pelletCount == 1) ? 0f : (float)i / (pelletCount - 1);
            float currentAngle = Mathf.Lerp(-halfSpread, halfSpread, t);

            // Rotate the firePoint’s forward vector by currentAngle around up (Y)
            Quaternion pelletRotation = Firepoint.rotation * Quaternion.Euler(0f, currentAngle, 0f);

            // Spawn & launch
            GameObject pellet = ObjectPoolManager.SpawnObject(
                ShotPrefab,
                Firepoint.position,
                pelletRotation,
                ObjectPoolManager.PoolType.GameObject
            );
            Rigidbody rb = pellet.GetComponent<Rigidbody>();
            rb.velocity = pelletRotation * Vector3.forward * shotSpeed;
        }

        IsOnCooldown = true;
        CooldownTimer = Cooldown;
        AbilityCount--;
    }
}
