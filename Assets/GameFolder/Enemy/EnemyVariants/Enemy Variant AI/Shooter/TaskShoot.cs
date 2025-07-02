using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using static UnityEngine.Rendering.DebugUI;

public class TaskShoot : Node
{

    private bool isAttacking;
    private float attackTimer = 0f;
    private float attackDuration = 3f;

    private GameObject _projectilePrefab;
    private Transform _projectileSpawn;
    private float _shotSpeed;
    private float _cooldownTimer = 0f;
    private float _cooldownTime = 1f;

    public TaskShoot(GameObject projectilePrefab, Transform projectileSpawn, float shotSpeed)
    {
        _projectilePrefab = projectilePrefab;
        _projectileSpawn = projectileSpawn;
        _shotSpeed = shotSpeed;
    }
     
    public override NodeState Evaluate()
    {
        object t = GetData("target");

        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        _cooldownTimer -= Time.deltaTime;

        if(_cooldownTimer < 0.01f)
        {
            Vector3 direction = (target.position - _projectileSpawn.position).normalized;

            GameObject bullet = ObjectPoolManager.SpawnObject(_projectilePrefab, _projectileSpawn.position, Quaternion.LookRotation(direction), ObjectPoolManager.PoolType.GameObject);
            bullet.GetComponent<Rigidbody>().velocity = direction * _shotSpeed;

            _cooldownTimer = _cooldownTime;
        }

        state = NodeState.SUCCESS;
        return state;

    }

}
