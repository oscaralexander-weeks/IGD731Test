using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using UnityEditor;

public class CheckStatusEffects : Node
{
    private Enemy _enemy;
    private Transform _target;
    public CheckStatusEffects(Enemy enemy, Transform target)
    {
        _enemy = enemy;
        _target = target;
    }

    public override NodeState Evaluate()
    {
        object e = GetData("enemy");
        Enemy enemy = (Enemy)e;

        if(e != null)
        {
            if (enemy.IsHit)
            {
                parent.parent.SetData("target", _target);
            }

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
