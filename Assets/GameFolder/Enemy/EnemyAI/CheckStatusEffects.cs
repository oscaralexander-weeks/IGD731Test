using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using UnityEditor;

public class CheckStatusEffects : Node
{
    private Enemy _enemy;
    public CheckStatusEffects(Enemy enemy)
    {
        _enemy = enemy;
    }

    public override NodeState Evaluate()
    {
        object e = GetData("enemy");

        if(e != null)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            parent.parent.SetData("enemy", _enemy);
        }

        state = NodeState.FAILURE;
        return state;
    }
}
