using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleUnitProjectile : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject ProjectilePrefab;
    public Transform ProjectileSpawn;

    [Header("Counts")]
    public float ShotSpeed;
    public float Cooldown;
    public bool CanShoot;
    
    public void ShootProjectile()
    {
        if (CanShoot)
        {
            if(ProjectilePrefab != null && ProjectileSpawn != null)
            {
                GameObject bullet = ObjectPoolManager.SpawnObject(ProjectilePrefab, ProjectileSpawn.position, ProjectileSpawn.rotation, ObjectPoolManager.PoolType.GameObject);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * ShotSpeed;
            }

            StartCoroutine(ShotCooldown());
            if (ProjectilePrefab == null || ProjectileSpawn == null)
            {
                Debug.LogWarning("Trap Not Set Up In Inspector");
            }
        }

    }


    private IEnumerator ShotCooldown()
    {
        CanShoot = false;

        yield return new WaitForSeconds(Cooldown);

        CanShoot = true;
    }
}
