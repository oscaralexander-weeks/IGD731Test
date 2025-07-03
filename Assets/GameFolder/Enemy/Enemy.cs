using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Systems")]
    public EnemyRuntimeSet runtimeSet;
    public UnityEvent onUnitDeath;
    public UnityEvent onUnitHit;
    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem instanceDamageParticles;

    [Header("EnemyStats")]
    public string enemyName;
    public int unitHealth;
    public bool HasStatusEffect;
    public bool IsHit;

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
