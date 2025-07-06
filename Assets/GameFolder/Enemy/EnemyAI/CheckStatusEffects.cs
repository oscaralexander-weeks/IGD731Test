using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using UnityEditor;

public class CheckStatusEffects : Node
{
    private Enemy _enemy;
    private Transform _target;

    private float _responseTimer = 0f;
    private float _responseTime = 0.2f;

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
                _responseTimer += Time.deltaTime;
                if(_responseTimer > _responseTime)
                {
                    parent.parent.SetData("target", _target);
                    _responseTimer = 0f;
                }
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
