using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Enemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        enemy = other.GetComponent<Enemy>();

        if(enemy != null)
        {
            StartCoroutine(WillThisWork());
        }
    }

    private IEnumerator WillThisWork()
    {
        enemy.HasStatusEffect = true;

        yield return new WaitForSeconds(2f);

        enemy.HasStatusEffect = false;
        Destroy(gameObject);

    }

}
