using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    public EnemyRuntimeSet runtimeSet;
    public string enemyName;

    public int unitHealth;
    public UnityEvent onUnitDeath;

    public bool HasStatusEffect;

    private void OnEnable()
    {
        runtimeSet.Add(this);
        Debug.Log(enemyName);
    }

    private void OnDisable()
    {
        runtimeSet.Remove(this);
    }

    public void TakeDamage(int damage)
    {
        unitHealth -= damage;
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
}
