using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBaseClass : MonoBehaviour
{
    [Header("Ability")]
    public float AbilityCooldown;
    public int AbilityCount;
    public bool IsOnCooldown;
    public GameObject AbilityPrefab;
    //public Transform AbilitySpawnPoint;

    public virtual void Ability(Transform abilitySpawnPoint)
    {

    }
}
