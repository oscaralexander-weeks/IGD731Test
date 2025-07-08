using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : ProjectBaseClass
{
    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
        Physics.IgnoreLayerCollision(3, 7);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            enemy.IsHit = true;
            OnStyleIncrease?.Invoke();
            Destroy(gameObject);
        }
    }
}
