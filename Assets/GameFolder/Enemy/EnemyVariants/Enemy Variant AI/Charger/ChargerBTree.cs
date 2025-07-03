using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class ChargerBTree : BTree
{
    public static float fovRange = 6f;
    
    private Enemy _enemy;
    private PlayerControllerWASD _player;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _player = GameObject.FindObjectOfType<PlayerControllerWASD>();
    }

    protected override Node SetUpTree()
    {

        Node root = new Selector(new List<Node>
        {
            new BehaviourTree.Sequence(new List<Node>
        {
            new CheckPlayerStats(_player),
            new CheckEnemyInAttackRange(transform),
            new TaskChargeAttack(transform)
        }),

            new CheckEnemyInFOVRange(transform)

        });

        return root;
    }
}
