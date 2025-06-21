using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AbilityHandler : MonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] private List<Transform> abilitySpawns = new List<Transform>();
    [SerializeField] private List<GameObject> abilityPrefabs = new List<GameObject>();
    [SerializeField] private List<AbilityBaseClass> abilities = new List<AbilityBaseClass>();

    private Transform testTransform;

    [Header("Events")]
    public UnityEvent onStyleIncrease;
    public UnityEvent onStyleDecrease;

    //public Canvas abilityCanvas;
    //public Image abilityRange;
    [Header("AOESpell")]
    public float maxAbilityDistance = 7;
    public int AOESpellDamage;
    [SerializeField] private ParticleSystem damageParticles;
    private ParticleSystem insatanceDamageParticles;
    [SerializeField] private int layer = 8;
    private int layerAsLayerMask;

    private Vector3 pos;
    private Ray ray;
    private RaycastHit hit;


    public Color sphereColor = Color.yellow;
    public float castRadius;

    private void Start()
    {
        testTransform = abilitySpawns[1];
        layerAsLayerMask = (1 << layer);
        abilities[0].AbilityCount = 5;
    }


    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        AbilityCanvas();
    }

    private void AbilityCanvas()
    {

        int layerMask = ~LayerMask.GetMask("Player");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.gameObject != this.gameObject)
            {
                pos = hit.point;
            }
        }

        var hitPosDir = (hit.point - transform.position).normalized;
        float distance = Vector3.Distance(hit.point, transform.position);
        distance = Mathf.Min(distance, maxAbilityDistance);

        var newHitPos = transform.position + hitPosDir * distance;
        //abilityCanvas.transform.position = (newHitPos);
        testTransform.position = (newHitPos);
    }

    public void OnAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UseAbility(0);
        }
    }

    private void UseAbility(int index)
    {
        if(abilities.Count > 0 && abilitySpawns.Count > 0 && abilities[index] != null)
        {
            if (!abilities[index].IsOnCooldown)
            {
                abilities[index].Ability(testTransform);
                StartCoroutine(Cooldown(abilities[index], abilities[index].AbilityCooldown));
            }
        }
    }

    public void OnAbility2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(AttackSequence());
        }
    }

    private void OnDrawGizmos()
    {
        if(testTransform != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(testTransform.position, castRadius);
        }
    }


    public void CheckAOE()
    {
        Collider[] colliders = Physics.OverlapSphere(testTransform.position, castRadius, layerAsLayerMask);
        int hits = 0;

        foreach (Collider c in colliders)
        {
            if (c.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if(enemy != null)
                {
                    enemy.TakeDamage(AOESpellDamage);
                    onStyleIncrease?.Invoke();
                    hits++;
                }
            }
        }

        if(hits == 0)
        {
            onStyleDecrease?.Invoke();
        }
    }

    private IEnumerator AttackSequence()
    {
        yield return new WaitForSeconds(0.25f);
        //start particles
        SpawnDamageParticles();
        CheckAOE();
        yield return new WaitForSeconds(1f);
        //end particles

    }

    private void SpawnDamageParticles()
    {
        if(damageParticles != null)
        {
            insatanceDamageParticles = Instantiate(damageParticles, testTransform);
        }
    }

    private IEnumerator Cooldown(AbilityBaseClass ability, float cooldown)
    {
        ability.IsOnCooldown = true;
        yield return new WaitForSeconds(cooldown);
        ability.IsOnCooldown = false;
    }

}
