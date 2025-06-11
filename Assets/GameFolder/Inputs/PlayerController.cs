using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using Unity.Mathematics;

public class PlayerController : MonoBehaviour
{
    ClickToMove input;

    NavMeshAgent agent;

    public NewItemRuntimeSet runtimeSet;

    [Header("Movement")]
    [SerializeField] private LayerMask clickableLayers;
    [SerializeField] float lookRotationSpeed = 8f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        input = new ClickToMove();
    }

    public void MovementEvent(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RightClickMove();
        }
    }

    public void RightClickMove()
    {
        //Debug.Log("hit");
        RaycastHit hit; 
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            //Debug.Log("hit2");
            agent.destination = hit.point;
        }
    }

    private void Update()
    {
        FaceTarget();
    }

    void FaceTarget()
    {

        Vector3 diff = agent.destination - transform.position;

        // If the difference is negligible, skip rotation
        if (diff.sqrMagnitude < 0.01f)
            return;

        Vector3 direction = diff.normalized;
        Vector3 flatDirection = new Vector3(direction.x, 0, direction.z);

        // Ensure flatDirection is non-zero before proceeding
        if (flatDirection == Vector3.zero)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }

    public void UseItem1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UseItemAtIndex(0);
        }
    }
    public void UseItemAtIndex(int index)
    {
        if (index < runtimeSet.Items.Count && runtimeSet.Items[index] != null && runtimeSet.Items[index].stackSize.Value > 0)
        {
            Debug.Log("itemUsed");
            runtimeSet.Items[index].Use();

        }
        else
        {
            Debug.Log("no item");
        }
    }

}
