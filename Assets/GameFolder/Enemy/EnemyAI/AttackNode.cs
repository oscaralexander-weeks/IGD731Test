using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
using Unity.VisualScripting;
public class AttackNode : Node
{

    private float _attackTime = 1f;
    private float _attackCounter = 0f;

    private PlayerStats _player;
    

    public AttackNode(PlayerStats player)
    {
        _player = player;
    }

    public override NodeState Evaluate()
    {

        _attackCounter += Time.deltaTime;
        if(_attackCounter >= _attackTime)
        {
            _player.TakeDamage(PatrolBTVariant.damage);
            _attackCounter = 0f;
        }

        state = NodeState.RUNNING;
        return state;
    }

    
}
