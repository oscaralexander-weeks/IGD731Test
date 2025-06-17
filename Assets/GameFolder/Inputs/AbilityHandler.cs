using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AbilityHandler : MonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] private List<Transform> abilitySpawns = new List<Transform>();
    [SerializeField] private List<GameObject> abilityPrefabs = new List<GameObject>();

    private Transform testTransform;

    //public Canvas abilityCanvas;
    //public Image abilityRange;
    public float maxAbilityDistance = 7;

    private Vector3 pos;
    private Ray ray;
    private RaycastHit hit;


    public Color sphereColor = Color.yellow;
    public float castRadius;

    private void Start()
    {
        testTransform = abilitySpawns[1];
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
            Ability(0);
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

    public void Ability(int index)
    {
        if (abilityPrefabs.Count > 0 && abilitySpawns.Count > 0)
        {
            Instantiate(abilityPrefabs[index], abilitySpawns[index].position, abilitySpawns[index].rotation);
        }

        //Debug.Log("No Ability");
    }


    public void CheckAOE()
    {
        Collider[] colliders = Physics.OverlapSphere(testTransform.position, castRadius);

        foreach (Collider c in colliders)
        {
            if (c.GetComponent<Enemy>())
            {
                c.GetComponent<Enemy>().TakeDamage(50);
            }
        }
    }

    private IEnumerator AttackSequence()
    {
        yield return new WaitForSeconds(0.25f);
        //start particles
        CheckAOE();
        yield return new WaitForSeconds(1f);
        //end particles

    }
}
