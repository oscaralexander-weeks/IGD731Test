using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectUnit : MonoBehaviour
{

    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem instanceDamageParticles;

    public void SpawnDamageParticles(Transform abiltySpawnPoint)
    {
        if (damageParticles != null)
        {
            instanceDamageParticles = Instantiate(damageParticles, abiltySpawnPoint);
        }
    }
}
