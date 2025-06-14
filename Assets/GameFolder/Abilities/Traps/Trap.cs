using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private GuardBT enemy;

    private void OnTriggerEnter(Collider other)
    {
        enemy = other.GetComponent<GuardBT>();

        if(enemy != null)
        {
            StartCoroutine(WillThisWork());
        }
    }


    private IEnumerator WillThisWork()
    {
        enemy.gameObject.transform.position = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(2);

    }

}
