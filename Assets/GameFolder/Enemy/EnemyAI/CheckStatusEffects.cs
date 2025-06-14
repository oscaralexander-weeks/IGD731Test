using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class CheckStatusEffects : Node
{
    private bool _isUnderStatus = false;

    private float _statusTimer = 2.0f;
    private float _statusDuration = 2.0f;

    public CheckStatusEffects(bool statusEffect)
    {
        _isUnderStatus = statusEffect;
    }

    public override NodeState Evaluate()
    {
        //object e = GetData("enemy");

        if (_isUnderStatus)
        {
            Debug.Log("found status");
            _statusTimer -= Time.deltaTime;
            state = NodeState.RUNNING;
            return state;
        }

        if(_statusTimer < 0.01f)
        {
            _isUnderStatus = false;
            _statusTimer = _statusDuration;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
