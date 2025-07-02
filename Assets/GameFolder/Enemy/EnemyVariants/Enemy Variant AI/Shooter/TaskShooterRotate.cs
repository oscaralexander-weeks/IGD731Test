using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class TaskShooterRotate : Node
{
    public Transform _transform;

    public TaskShooterRotate(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        _transform.Rotate(0, 20 * Time.deltaTime, 0);

        state = NodeState.RUNNING;
        return state;
    }
}
