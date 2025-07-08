using System.Collections;
using UnityEngine;

public class WallSnakeEnemy : MonoBehaviour
{
    [Header("Snake Settings")]
    public Transform snakeModel;              // The visible snake object
    public float popOutDistance = 1.5f;       // How far it moves out
    public float popOutSpeed = 3f;
    public float retreatDelay = 1.5f;
    public int biteDamage = 10;
    public Vector3 popOutDirection = Vector3.forward;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool isStriking = false;
    private bool playerInZone = false;
    private Coroutine attackCoroutine;

    private void Start()
    {
        if (snakeModel == null) snakeModel = transform;

        startPos = snakeModel.position;
        endPos = startPos + transform.TransformDirection(popOutDirection.normalized) * popOutDistance;
        snakeModel.position = startPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isStriking)
        {
            playerInZone = true;
            attackCoroutine = StartCoroutine(PopOutAndStrike(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;

            if (attackCoroutine != null)
                StopCoroutine(attackCoroutine);

            // Instantly reset snake to start position
            snakeModel.position = startPos;
            isStriking = false;
        }
    }

    private IEnumerator PopOutAndStrike(Collider player)
    {
        isStriking = true;

        // Pop out
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * popOutSpeed;
            snakeModel.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        // Bite
        IDamageable damageable = player.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(biteDamage);
        }

        // Wait before retreating
        yield return new WaitForSeconds(retreatDelay);

        // Retreat
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * popOutSpeed;
            snakeModel.position = Vector3.Lerp(endPos, startPos, t);
            yield return null;
        }

        // Allow re-triggering if player is still in zone
       // if (playerInZone)
        //{
        //    attackCoroutine = StartCoroutine(PopOutAndStrike(player));
        //}
        //else
        //{
        //    isStriking = false;
        //}
    }
}
