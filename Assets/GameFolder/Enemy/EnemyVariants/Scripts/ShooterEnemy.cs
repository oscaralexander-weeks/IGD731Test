using System.Collections;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [Header("Shooting Settings")]
    public GameObject pelletPrefab;
    public Transform shootPoint;
    public float shootInterval = 2f;
    public float pelletSpeed = 10f;
    public Transform player;

    private Coroutine shootingCoroutine;
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (shootingCoroutine == null)
            {
                shootingCoroutine = StartCoroutine(ShootAtPlayer());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
            }
        }
    }

    private IEnumerator ShootAtPlayer()
    {
        while (playerInRange)
        {
            yield return new WaitForSeconds(shootInterval);

            if (player == null) continue;

            Vector3 direction = (player.position - shootPoint.position).normalized;

            GameObject pellet = Instantiate(pelletPrefab, shootPoint.position, Quaternion.LookRotation(direction));
            Rigidbody rb = pellet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * pelletSpeed;
            }
        }
    }

    private void OnDisable()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }
}
