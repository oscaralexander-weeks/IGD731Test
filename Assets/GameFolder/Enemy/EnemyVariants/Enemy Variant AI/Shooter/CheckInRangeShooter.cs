using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class CheckInRangeShooter : Node 
{

    private Transform _transform;

    public CheckInRangeShooter(Transform transform)
    {
        _transform = transform;
    }


    public override NodeState Evaluate()
    {
        object t = GetData("target");
        Vector3 forward = _transform.TransformDirection(Vector3.forward) * 25;
        Debug.DrawRay(_transform.position, forward);

        if (t == null)
        {
            //LayerMask playerLayer = LayerMask.GetMask("Player");

            RaycastHit hit;
            if (Physics.Raycast(_transform.position, _transform.forward, out hit, 25, ShooterBT.enemyDetectionLayers))
            {
                //Debug.Log("hit");
                if (hit.transform.gameObject.GetComponent<PlayerControllerWASD>())
                {
                    Debug.Log("hit shooter");
                    parent.parent.SetData("target", hit.transform);
                    state = NodeState.SUCCESS;
                    return state;
                }
            }
        }

        if (t != null)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }

}
