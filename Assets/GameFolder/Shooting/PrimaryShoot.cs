using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryShoot : BaseDefaultWeapon
{

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
        if (!IsOnCooldown)
        {
            var bullet = Instantiate(ShotPrefab, Firepoint.position, Firepoint.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * ShotSpeed;

            Destroy(bullet, ShotDecay);

            IsOnCooldown = true;
        }
    }
}
