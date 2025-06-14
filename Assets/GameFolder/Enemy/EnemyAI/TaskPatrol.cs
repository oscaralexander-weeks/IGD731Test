using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class TaskPatrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;

    private int _currentWaypointIndex;
    private float waitTime = 1f;
    private float waitCounter = 0f;

    private bool _isWaiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
    }

    public override NodeState Evaluate()
    {

        Enemy enemy = (Enemy)GetData("enemy");
        if (enemy != null && enemy.HasStatusEffect)
        {
            // If stunned, skip movement.
            state = NodeState.FAILURE;  // or state = NodeState.RUNNING depending on your logic.
            return state;
        }

        if (_isWaiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter < waitTime)
            _isWaiting = false;
        }
        else
        {
            Transform wp = _waypoints[_currentWaypointIndex];
            if (Vector3.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                waitCounter = 0f;
                _isWaiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _transform.position = Vector3.MoveTowards(_transform.position, wp.position, GuardBT.speed * Time.deltaTime);
                _transform.LookAt(wp.position);
            }
        }

        

        state = NodeState.RUNNING;
        return state;
    }
}
