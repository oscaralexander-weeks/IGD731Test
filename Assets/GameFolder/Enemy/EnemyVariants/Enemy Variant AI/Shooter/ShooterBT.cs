using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class ShooterBT : BTree
{
    private Enemy _enemy;
    private PlayerStats _player;
    [SerializeField] private GameObject ShotPrefab;
    public float ShotSpeed;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _player = GameObject.FindObjectOfType<PlayerStats>();
    }

    protected override Node SetUpTree()
    {

        Node root = new Selector(new List<Node>
        {

            new Sequence(new List<Node>
            {
                new CheckStatusEffects(_enemy, _player.transform),
                new CheckPlayerStats(_player),
                new CheckInRangeShooter(transform),
                new TaskAimAtPlayer(transform),
                new TaskShoot(ShotPrefab, transform, ShotSpeed)
            }),

            new TaskShooterRotate(transform)

        });

        return root;
    }
}
