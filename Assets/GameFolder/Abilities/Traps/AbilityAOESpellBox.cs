using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbilityAOESpellBox : AbilityBaseClass
{
    [Header("Events")]
    public UnityEvent onStyleIncrease;
    public UnityEvent onStyleDecrease;

    [Header("AOESpell")]
    public int AOESpellDamage;
    //[SerializeField] private ParticleSystem damageParticles;
    [SerializeField] private int layer = 8;
    //private ParticleSystem instanceDamageParticles;
    private int layerAsLayerMask;

    private Collider[] colliders = new Collider[10];

    public Vector3 hitBox = Vector3.one;

    private void Start()
    {
        layerAsLayerMask = (1 << layer);
    }

    public void CheckAOE(Transform abiltySpawnPoint)
    {
        //Collider[] colliders = Physics.OverlapSphere(abiltySpawnPoint.position, castRadius, layerAsLayerMask);
        //int hits = 0
        ClearArray();
        int hitCount = Physics.OverlapBoxNonAlloc(abiltySpawnPoint.position, hitBox, colliders, abiltySpawnPoint.rotation, layerAsLayerMask);

        for (int i = 0; i < hitCount; i++)
        {
            Collider c = colliders[i];

            if (c.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (enemy != null)
                {
                    enemy.TakeDamage(AOESpellDamage);
                    //onStyleIncrease?.Invoke();
                    //hits++;
                }
            }
        }

        /*
        foreach (Collider c in colliders)
        {
            if (c.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (enemy != null)
                {
                    enemy.TakeDamage(AOESpellDamage);
                    //onStyleIncrease?.Invoke();
                    //hits++;
                }
            }
        }
        */
        //if (hits == 0)
        //{
        //    onStyleDecrease?.Invoke();
        //}
    }

    private IEnumerator AttackSequence(Transform abiltySpawnPoint)
    {
        yield return new WaitForSeconds(0.25f);
        //start particles
        //SpawnDamageParticles(abiltySpawnPoint);
        CheckAOE(abiltySpawnPoint);
        yield return new WaitForSeconds(1f);
        //end particles

    }
    /*
    private void SpawnDamageParticles(Transform abiltySpawnPoint)
    {
        if (damageParticles != null)
        {
            instanceDamageParticles = Instantiate(damageParticles, abiltySpawnPoint);
        }
    }
    */
    public override void Ability(Transform abilitySpawnPoint)
    {
        StartCoroutine(AttackSequence(abilitySpawnPoint));
    }

    private void ClearArray()
    {
        System.Array.Clear(colliders, 0, colliders.Length);
    }
}
