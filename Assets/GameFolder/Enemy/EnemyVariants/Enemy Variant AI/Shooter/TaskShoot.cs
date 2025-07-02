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
        Vector3 direction = (target.position - _projectileSpawn.position).normalized;

        if (!isAttacking)
        {
            isAttacking = true;
            attackTimer = attackDuration;
            GameObject bullet = ObjectPoolManager.SpawnObject(_projectilePrefab, _projectileSpawn.position, Quaternion.LookRotation(direction), ObjectPoolManager.PoolType.GameObject);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _shotSpeed;
        }

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            state = NodeState.RUNNING;
            return state;
        }
        else
        {

            state = NodeState.SUCCESS;
            isAttacking = false;
            return state;
        }
    }

}
