using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyProjectileBaseClass : ProjectBaseClass
{
    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
        Physics.IgnoreLayerCollision(9, 8);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();

        if (player != null)
        {
            player.TakeDamage(damage);
            OnStyleDecrease?.Invoke();
            Destroy(gameObject);
        }

    }
}
