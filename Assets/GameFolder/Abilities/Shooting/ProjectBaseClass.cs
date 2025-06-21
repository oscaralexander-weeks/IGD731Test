using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectBaseClass : MonoBehaviour
{
    public UnityEvent OnProjectileHit;
    public int damage;


    [Header("Style Events")]
    public UnityEvent OnStyleIncrease;
    public UnityEvent OnStyleDecrease;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(0, 7);
        //OnStyleDecrease?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            OnStyleIncrease?.Invoke();
        }

    }

}
