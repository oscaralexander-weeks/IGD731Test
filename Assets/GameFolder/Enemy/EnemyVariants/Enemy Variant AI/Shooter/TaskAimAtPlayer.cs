using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class TaskAimAtPlayer : Node
{
    public Transform _transform;

    public TaskAimAtPlayer(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        Transform target = (Transform)t;

        if(t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        _transform.LookAt(target);
        state = NodeState.RUNNING;
        return state;
    }
}
