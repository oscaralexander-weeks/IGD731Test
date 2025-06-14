using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrimaryFire : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject shotPrefab;

    public float shotSpeed;
    public float shotDecay;
    //[SerializeField] private Transform orient;

    private int ammo;
    [SerializeField] private float reloadTime = 0.5f;
    [SerializeField] private bool isReloading = false;

    private void Start()
    {
        //InvokeRepeating("LeftClickShoot", 1, 3);
    }

    private void Update()
    {
        
        if (isReloading)
        {
            reloadTime -= Time.deltaTime;

            if (reloadTime < 0)
            {
                isReloading = false;
                reloadTime = 0.5f;
            }
        }
    }

    public void LeftClickShoot()
    {

        if (!isReloading)
        {
            var bullet = Instantiate(shotPrefab, firepoint.position, firepoint.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * shotSpeed;

            Destroy(bullet, shotDecay);

            isReloading = true;
        }

    }



}
 