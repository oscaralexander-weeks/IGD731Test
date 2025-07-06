using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleUnitProjectile : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform ProjectileSpawn;
    public float ShotSpeed;

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

        yield return new WaitForSeconds(1);

        CanShoot = true;
    }
}
