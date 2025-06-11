using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public FloatReference playerHealth;

    public void dealDamage(int damage)
    {
        playerHealth.Variable.ApplyChange(-damage);
    }
}
