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

    private void Start()
    {
        //InvokeRepeating("LeftClickShoot", 1, 3);
    }


    public void LeftClickShoot()
    {
        var bullet = Instantiate(shotPrefab, firepoint.position, firepoint.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * shotSpeed;

        Destroy(bullet, shotDecay);
    }



}
 