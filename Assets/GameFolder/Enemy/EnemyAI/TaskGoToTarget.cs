using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class TaskGoToTarget : Node
{

    private Transform _transform;

    public TaskGoToTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        // Check enemy status before moving.
        Enemy enemy = (Enemy)GetData("enemy");
        if (enemy != null && enemy.HasStatusEffect)
        {
            // If stunned, skip movement.
            state = NodeState.FAILURE;  // or state = NodeState.RUNNING depending on your logic.
            return state;
        }

        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, target.position, GuardBT.speed * Time.deltaTime);
            _transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }

}
