using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUnitProjectile : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform ProjectileSpawn;
    public float ShotSpeed;

    public void ShootProjectile()
    {
        if(ProjectilePrefab != null && ProjectileSpawn != null)
        {
            GameObject bullet = ObjectPoolManager.SpawnObject(ProjectilePrefab, ProjectileSpawn.position, ProjectileSpawn.rotation, ObjectPoolManager.PoolType.GameObject);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * ShotSpeed;
        }

        if (ProjectilePrefab == null && ProjectileSpawn == null)
        {
            Debug.LogWarning("Trap Not Set Up In Inspector");
        }
    }
}
