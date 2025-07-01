using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class CheckPlayerInRangeRay : Node 
{
    private Transform _transform;
    public CheckPlayerInRangeRay(Transform transform)
    {
        _transform = transform;
    }


    public override NodeState Evaluate()
    {
        object t = GetData("target");
        Vector3 forward = _transform.TransformDirection(Vector3.forward) * 50;
        Debug.DrawRay(_transform.position, forward);
        
        if (t == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(_transform.position, _transform.forward, out hit, 50))
            {
                Debug.Log("hit");
                parent.parent.SetData("target", hit.transform);
                state = NodeState.SUCCESS;
                return state;
            }

        }

        if(t != null)
        {
            state = NodeState.SUCCESS;
            return state;
        }


        state = NodeState.FAILURE;
        return state;
    }
}
