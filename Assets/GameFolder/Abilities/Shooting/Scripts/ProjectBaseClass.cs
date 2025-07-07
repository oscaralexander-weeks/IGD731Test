using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectBaseClass : MonoBehaviour
{
    [Header("ProjectileInfo")]
    public UnityEvent OnProjectileHit;
    public int damage;
    public float DestroyTime;

    public Coroutine _returnToPoolTimerCoroutine;

    [Header("Style Events")]
    public bool CanDecreaseStyle;
    public UnityEvent OnStyleIncrease;
    public UnityEvent OnStyleDecrease;

    public IEnumerator ReturnToPoolAfterTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < DestroyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ObjectPoolManager.ReturnObjectToPool(gameObject);
        if (CanDecreaseStyle)
        {
            OnStyleDecrease?.Invoke();
        }
    }

}
