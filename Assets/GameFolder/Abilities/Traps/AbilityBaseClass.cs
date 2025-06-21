using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBaseClass : ScriptableObject
{
    [Header("Ability")]
    public int Cooldown;
    public int abilityCount;
    public GameObject AbilityPrefab;
    //public Transform AbilitySpawnPoint;

    public virtual void Ability(Transform abilitySpawnPoint)
    {

    }
}
