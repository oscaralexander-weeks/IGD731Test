using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryFire : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject shotPrefab;
    private PlayerControllerWASD _movement;


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
        _movement = GetComponent<PlayerControllerWASD>();
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
            StartCoroutine(ShootRoutine());

            isOnCooldown = true;
        }

    }

    public IEnumerator ShootRoutine()
    {
        //stop movement 
        if (_movement != null)
        {
            _movement.canMove = false;
            //start shooting coroutine
            yield return StartCoroutine(OtherShootRoutine());

            _movement.canMove = true;
        }
        
        //start movement
        
    }

    public IEnumerator OtherShootRoutine()
    {
        int i = 3;

        while(i > 0)
        {
            var bullet = Instantiate(shotPrefab, firepoint.position, firepoint.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * shotSpeed;

            Destroy(bullet, shotDecay);

            i--;
            yield return new WaitForSeconds(0.25f);
        }

        
    }
}
