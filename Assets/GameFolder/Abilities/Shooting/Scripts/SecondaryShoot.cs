using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SecondaryShoot : BaseDefaultWeapon
{
    private PlayerControllerWASD _movement;

    public override void Shoot()
    {
        if (!IsOnCooldown)
        {
            StartCoroutine(ShootRoutine());

            IsOnCooldown = true;

        }
    }

    private void Start()
    {
        //InvokeRepeating("LeftClickShoot", 1, 3);
        _movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerWASD>();
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

    public IEnumerator ShootRoutine()
    {
        //stop movement 
        if (_movement != null)
        {
            _movement.SpeedMultiplyer = 0.5f;
            //start shooting coroutine
            yield return StartCoroutine(OtherShootRoutine());

            _movement.SpeedMultiplyer = 1;
        }

        //start movement

    }

    public IEnumerator OtherShootRoutine()
    {
        int i = 3;

        while (i > 0)
        {
            var bullet = Instantiate(ShotPrefab, Firepoint.position, Firepoint.rotation);

            //var bullet = ObjectPoolManager.SpawnObject(ShotPrefab, Firepoint.position, Firepoint.rotation);
            
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * ShotSpeed;

            Destroy(bullet, ShotDecay);

            i--;
            yield return new WaitForSeconds(0.25f);
        }


    }

}
