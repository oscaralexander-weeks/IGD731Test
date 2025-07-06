using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Systems")]
    public EnemyRuntimeSet runtimeSet;
    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem instanceDamageParticles;

    [Header("EnemyStats")]
    public string enemyName;
    public int unitHealth;
    public bool HasStatusEffect;
    public bool IsHit;

    [Header("Events")]
    public UnityEvent onUnitDeath;
    public UnityEvent onUnitHit;
    public UnityEvent OnStyleIncrease;
    public UnityEvent OnStyleBoost;

    private void OnEnable()
    {
        runtimeSet.Add(this);
        //Debug.Log(enemyName);
    }

    private void OnDisable()
    {
        runtimeSet.Remove(this);
    }

    public void TakeDamage(int damage)
    {
        onUnitHit?.Invoke();
        unitHealth -= damage;
        SpawnDamageParticles(gameObject.transform);
        if(unitHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (HasStatusEffect)
        {
            OnStyleBoost?.Invoke();
        }
        else if (!HasStatusEffect)
        {
            OnStyleIncrease?.Invoke();
        }

        onUnitDeath?.Invoke();
        Destroy(gameObject);
    }

    private void SpawnDamageParticles(Transform abiltySpawnPoint)
    {
        if (damageParticles != null)
        {
            instanceDamageParticles = Instantiate(damageParticles, abiltySpawnPoint);
        }
    }
}
