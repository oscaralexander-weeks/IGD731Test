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
        if (!IsOnCooldown && AbilityCount > 0)
        {
            OnFire?.Invoke();

            //var bullet = Instantiate(ShotPrefab, Firepoint.position, Firepoint.rotation);

            GameObject bullet = ObjectPoolManager.SpawnObject(ShotPrefab, Firepoint.position, Firepoint.rotation, ObjectPoolManager.PoolType.GameObject);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * ShotSpeed;

            //Destroy(bullet, ShotDecay);

            IsOnCooldown = true;
            AbilityCount--;
        }
    }
}
