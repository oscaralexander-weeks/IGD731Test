using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBaseClass : AbilitiesSuperclass
{
    [Header("Ability")]
    public int AbilityCount;
    public GameObject AbilityPrefab;

    public virtual void Ability(Transform abilitySpawnPoint)
    {

    }
}
