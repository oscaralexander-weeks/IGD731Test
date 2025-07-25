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
    public UnityEvent OnStyleBoost;
    public UnityEvent OnStealthKill;

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

        HP.ApplyChange(-damage);
        OnPlayerHit?.Invoke();

        if (HP.Value <= 0)
        {
            Die();
        }
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

    public void CheckStealthKill()
    {
        if (IsStealth)
        {
            OnStyleBoost?.Invoke();
            OnStealthKill?.Invoke();
        }
    }
}
