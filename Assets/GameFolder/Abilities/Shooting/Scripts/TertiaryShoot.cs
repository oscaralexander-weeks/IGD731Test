using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TertiaryShoot : BaseDefaultWeapon
{
    public List<Transform> AdditionalFirepoints = new List<Transform>();

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
            GameObject bullet2 = ObjectPoolManager.SpawnObject(ShotPrefab, AdditionalFirepoints[0].position, AdditionalFirepoints[0].rotation, ObjectPoolManager.PoolType.GameObject);
            bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * ShotSpeed;
            GameObject bullet3 = ObjectPoolManager.SpawnObject(ShotPrefab, AdditionalFirepoints[1].position, AdditionalFirepoints[1].rotation, ObjectPoolManager.PoolType.GameObject);
            bullet3.GetComponent<Rigidbody>().velocity = bullet3.transform.forward * ShotSpeed;

            //Destroy(bullet, ShotDecay);

            IsOnCooldown = true;
            AbilityCount--;
        }

        if(AbilityCount == 0 || !HasAbilityCount)
        {
            Debug.LogWarning("Ability Count < 0 or false");
        }
    }
}
