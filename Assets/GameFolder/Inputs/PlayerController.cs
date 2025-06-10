using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    ClickToMove input;

    NavMeshAgent agent;

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
        Debug.Log("hit");
        RaycastHit hit; 
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            Debug.Log("hit2");
            agent.destination = hit.point;
        }
    }

}
