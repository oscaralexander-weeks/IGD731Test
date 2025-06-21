using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class AbilityTrap : AbilityBaseClass
{
    /*
    public void Ability()
    {
        /*
        if (abilityPrefabs.Count > 0 && abilitySpawns.Count > 0)
        {
            Instantiate(abilityPrefabs[index], abilitySpawns[index].position, abilitySpawns[index].rotation);
        }
        
        
        //Debug.Log("No Ability");
    }
    */

    public override void Ability(Transform abilitySpawnPoint)
    {
        if(AbilityCount > 0)
        {
            Instantiate(AbilityPrefab, abilitySpawnPoint.position, abilitySpawnPoint.rotation);
            AbilityCount--;
        }
    }
}
