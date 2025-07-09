using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapProjectile : ProjectBaseClass
{
    public UnityEvent OnEnvironmentKill;
    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            enemy.IsHit = true;
            OnStyleIncrease?.Invoke();
            OnEnvironmentKill?.Invoke();
            Destroy(gameObject);
        }

        if (player != null)
        {
            player.TakeDamage(damage);
            OnStyleDecrease?.Invoke();
            Destroy(gameObject);
        }
    }
}
