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
    [SerializeField] private FloatVariable HP;

    //additions I've made specific to this game 
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
                new CheckEnemyInAttackRangeBasic(transform),
                new AttackNode(HP)
            }),
            new BehaviourTree.Sequence(new List<Node>
        {
            new CheckPlayerStats(_player),
            new CheckPlayerInRangeRay(transform),
            new TaskGoToTarget(transform)
        }),
            new TaskPatrol(transform, waypoints)
        });

        return root;
    }
}
