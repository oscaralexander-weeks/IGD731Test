using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyProjectileBaseClass : MonoBehaviour
{
    [Header("ProjectileInfo")]
    public UnityEvent OnProjectileHit;
    public int damage;
    public float DestroyTime;

    private Coroutine _returnToPoolTimerCoroutine;

    [Header("Style Events")]
    public UnityEvent OnStyleIncrease;
    public UnityEvent OnStyleDecrease;

    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
        Physics.IgnoreLayerCollision(3, 8);
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

    private IEnumerator ReturnToPoolAfterTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < DestroyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
}
