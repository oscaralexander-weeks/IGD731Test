using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class PatrolBTVariant : BTree
{
    public Transform[] waypoints;
    public static float speed = 3f;
    public static float fovRange = 6f;
    public static float attackRange = 3f;
    public static int damage = 10;

    //additions I've made specific to this game 
    private Enemy _enemy;
    private PlayerStats _player;


    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _player = GameObject.FindObjectOfType<PlayerStats>();
    }

    protected override Node SetUpTree()
    {
        Node root = new Selector(new List<Node>
        {
            new BehaviourTree.Sequence(new List<Node>
            {
                new CheckPlayerStats(_player),
                new CheckEnemyInAttackRangeBasic(transform),
                new AttackNode(_player)
            }),
            new BehaviourTree.Sequence(new List<Node>
        {
                new CheckStatusEffects(_enemy, _player.transform),
                new CheckPlayerStats(_player),
                new CheckPlayerInRangeRay(transform),
                new TaskGoToTarget(transform)
        }),
            new TaskPatrol(transform, waypoints)
        });

        return root;
    }
}
