using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbilityAOESpellSmokebomb : AbilityBaseClass
{
    [Header("Events")]
    public UnityEvent onStyleIncrease;
    public UnityEvent onStyleDecrease;

    [Header("AOESpell")]
    [SerializeField] private ParticleSystem damageParticles;
    [SerializeField] private int layer = 6;
    private ParticleSystem insatanceDamageParticles;
    private int layerAsLayerMask;

    public float castRadius;

    private void Start()
    {
        layerAsLayerMask = (1 << layer);
    }

    public void CheckAOE(Transform abiltySpawnPoint)
    {
        Collider[] colliders = Physics.OverlapSphere(abiltySpawnPoint.position, castRadius, layerAsLayerMask);
        int hits = 0;

        foreach (Collider c in colliders)
        {
            if (c.TryGetComponent<PlayerControllerWASD>(out PlayerControllerWASD player))
            {
                if (player != null)
                {
                    player.IsStealth = true;
                }
            }
        }

        if (hits == 0)
        {
            onStyleDecrease?.Invoke();
        }
    }

    private IEnumerator AttackSequence(Transform abiltySpawnPoint)
    {
        yield return new WaitForSeconds(0.25f);
        //start particles
        SpawnDamageParticles(abiltySpawnPoint);
        CheckAOE(abiltySpawnPoint);
        yield return new WaitForSeconds(1f);
        //end particles

    }
    private void SpawnDamageParticles(Transform abiltySpawnPoint)
    {
        if (damageParticles != null)
        {
            insatanceDamageParticles = Instantiate(damageParticles, abiltySpawnPoint);
        }
    }

    public override void Ability(Transform abilitySpawnPoint)
    {
        StartCoroutine(AttackSequence(abilitySpawnPoint));
    }
}
