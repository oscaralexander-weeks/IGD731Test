using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{

    [Header("Stats")]
    public FloatVariable HP;
    public bool IsStealth;

    [Header("Events")]
    public UnityEvent OnPlayerHit;
    public UnityEvent OnPlayerDeath;

    private void Update()
    {
        CheckStealth();
    }


    public void TakeDamage(int damage)
    {
        if(HP == null)
        {
            Debug.LogWarning("HP not assigned");
        }

        if(HP.Value <= 0)
        {
            Die();
        }

        HP.ApplyChange(-damage);
        OnPlayerHit?.Invoke();
    }

    private void CheckStealth()
    {
        if (IsStealth)
        {
            StartCoroutine(ResetStealth());
        }
    }

    private IEnumerator ResetStealth()
    {
        yield return new WaitForSeconds(4);

        IsStealth = false;
    }

    public void Die()
    {
        OnPlayerDeath?.Invoke();
    }
}
