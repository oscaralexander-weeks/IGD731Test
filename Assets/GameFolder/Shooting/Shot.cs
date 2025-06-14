using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private Rigidbody rb;
    public float shotSpeed;
    public float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartShot();
    }

    private void StartShot()
    {
        rb.velocity = new Vector3(0f, 0f, shotSpeed);
        Destroy(gameObject, shotTime);
    }

}
