using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryFire : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject shotPrefab;

    public float shotSpeed;
    public float shotDecay;
    //[SerializeField] private Transform orient;

    private int ammo;
    public float cooldown, cooldownTimer;
    [SerializeField] private bool isOnCooldown = false;

    private void Start()
    {
        //InvokeRepeating("LeftClickShoot", 1, 3);
        cooldownTimer = cooldown;
    }

    private void Update()
    {

        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer < 0.01f)
            {
                isOnCooldown = false;
                cooldownTimer = cooldown;
            }
        }
    }
    public void Shoot()
    {

        if (!isOnCooldown)
        {
            var bullet = Instantiate(shotPrefab, firepoint.position, firepoint.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * shotSpeed;

            Destroy(bullet, shotDecay);

            isOnCooldown = true;
        }

    }
}
