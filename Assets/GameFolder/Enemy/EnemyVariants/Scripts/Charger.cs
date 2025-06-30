using UnityEngine;
using System.Collections;

public class Charger : Enemy
{
    public Transform player;
    public float chargeSpeed = 10f;
    public float chargeDistance = 5f;
    public float pauseTime = 1.5f;

    private bool isCharging = false;

    void Start()
    {
        StartCoroutine(ChargeLoop());
    }

    IEnumerator ChargeLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(pauseTime);

            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = startPosition + direction * chargeDistance;

            // Rotate to face the player
            transform.forward = direction;

            isCharging = true;

            while (Vector3.Distance(transform.position, startPosition) < chargeDistance)
            {
                transform.position += direction * chargeSpeed * Time.deltaTime;
                yield return null;
            }

            isCharging = false;
        }
    }
}
