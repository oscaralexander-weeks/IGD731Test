using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectBaseClass : MonoBehaviour
{
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
        Physics.IgnoreLayerCollision(0, 7);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            OnStyleIncrease?.Invoke();
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
