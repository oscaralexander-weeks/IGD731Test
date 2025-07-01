using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class PatrolBTVariant : BTree
{
    public Transform[] waypoints;
    public static float speed = 3f;
    public static float fovRange = 6f;
    [SerializeField] private FloatVariable HP;

    //additions I've made specific to this game 
    private Enemy _enemy;


    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    protected override Node SetUpTree()
    {
        Node root = new Selector(new List<Node>
        {
            new BehaviourTree.Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new AttackNode(HP)
            }),
            new BehaviourTree.Sequence(new List<Node>
        {
            new CheckPlayerInRangeRay(transform),
            new TaskGoToTarget(transform)
        }),
            new TaskPatrol(transform, waypoints)
        });

        return root;
    }
}
