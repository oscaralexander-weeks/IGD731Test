using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var collectible = other.GetComponent<ICollectible>();

        if(collectible != null)
        {
            collectible.Collect();
        }
    }
}
