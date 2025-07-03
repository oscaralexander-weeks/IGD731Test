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
    private Transform _transform;

    public static int _playerLayer = 1 << 6;
    private float _castRadius = 4f;

    public AttackNode(PlayerStats player, Transform transform)
    {
        _player = player;
        _transform = transform;
    }

    public override NodeState Evaluate()
    {

        _attackCounter += Time.deltaTime;
        if(_attackCounter >= _attackTime)
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, _castRadius, _playerLayer);

            if(colliders.Length > 0)
            {
                _player.TakeDamage(PatrolBTVariant.damage);
                _attackCounter = 0f;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }

    
}
