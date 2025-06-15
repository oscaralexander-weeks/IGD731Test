using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerWASD : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    private Vector2 _move, _mouseLook;
    private Vector3 _rotationTarget;
    public bool canMove;

    [Header ("Weapons")]
    public List<BaseDefaultWeapon> Weapons = new List<BaseDefaultWeapon>();
    [SerializeField] private List<Transform> abilitySpawns = new List<Transform>();
    [SerializeField] private List<GameObject> abilityPrefabs = new List<GameObject>();
    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        _mouseLook = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot(0);
        }
    }

    public void OnShoot2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot(1);
        }
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

    public void Ability(int index)
    {
        if(abilityPrefabs.Count > 0 && abilitySpawns.Count > 0)
        {
            Instantiate(abilityPrefabs[index], abilitySpawns[index].position, abilitySpawns[index].rotation);
        }

        //Debug.Log("No Ability");
    }


    public void CheckAOE()
    {
        Collider[] colliders = Physics.OverlapSphere(abilitySpawns[0].position, 4f);

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


    public void Shoot(int index)
    {
        Weapons[index].Shoot();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(_mouseLook);
        

        if (Physics.Raycast(ray, out hit))
        {
            _rotationTarget = hit.point;
        }

        MovePlayerWithAim();

        //MovePlayer();

    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(_move.x, 0f, _move.y);

        if(movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void MovePlayerWithAim()
    {
        var lookPosition = _rotationTarget - transform.position;
        lookPosition.y = 0;
        var rotation = Quaternion.LookRotation(lookPosition);

        Vector3 aimDirection = new Vector3(_rotationTarget.x, 0f, _rotationTarget.z);

        if(aimDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
        }

        if (canMove)
        {
            Vector3 movement = new Vector3(_move.x, 0f, _move.y);

            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }


    }
}
