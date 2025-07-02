using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
public class TaskChargeAttack : Node
{
    private float _cooldownTimer = 0f;
    private float _cooldownTime = 1f;

    private Transform _transform;

    public TaskChargeAttack(Transform transform)
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

        if(target != null)
        {
            _cooldownTimer -= Time.deltaTime;

            if(_cooldownTimer < 0.01f)
            {
                Vector3 direction = (target.position - _transform.position).normalized;

                if(Vector3.Distance(_transform.position, target.position) < 5f)
                {
                    Debug.Log("charge");
                    _transform.position += direction * 10f * Time.deltaTime;
                    _cooldownTimer = _cooldownTime;
                    state = NodeState.RUNNING;
                    return state;
                }
            }
        }

        state = NodeState.FAILURE;
        return state;
    }
}
