using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBaseClass : MonoBehaviour
{
    [Header("Ability")]
    public float AbilityCooldown;
    public float AbilityCooldownTimer;
    public int AbilityCount;
    public bool IsOnCooldown;
    public GameObject AbilityPrefab;
    public string AbilityName;

    public virtual void Ability(Transform abilitySpawnPoint)
    {

    }
}
