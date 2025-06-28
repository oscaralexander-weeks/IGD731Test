using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardBT : BTree
{
    public Transform[] waypoints;
    public static float speed = 3f;
    public static float fovRange = 6f;
    public static float attackRange = 3f;

    //additions I've made specific to this game 
    public FloatVariable HP;
    private Enemy _enemy;
    private PlayerControllerWASD _player;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _player = GameObject.FindObjectOfType<PlayerControllerWASD>();
    }

    protected override Node SetUpTree()
    {
        /*
        Node root = new Selector(new List<Node>
        {
            new BehaviourTree.Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform)
            }),
            new TaskPatrol(transform, waypoints)

        });
        this code works now testing 
        
        HERE FOR LATEST BLOCK OF CODE INCLUDING TEST - NOW TESTING PATROL SEPARATELY 
        
        Node root = new Selector(new List<Node>
        {
            new BehaviourTree.Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
                new AttackNode(HP)
            }),
            new TaskPatrol(transform, waypoints)

        });
        */

        Node root = new Selector(new List<Node>
        {
            new BehaviourTree.Sequence(new List<Node>
        {
            new CheckPlayerStats(_player),
            new CheckEnemyInAttackRange(transform),
            new AttackNode(HP)
        }),

            new BehaviourTree.Sequence(new List<Node>
            {
                new CheckPlayerStats(_player),
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
                //new AttackNode(HP)
            }),
            new TaskPatrol(transform, waypoints)

        });

        return root;
    }
}
