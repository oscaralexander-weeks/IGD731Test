using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public FloatReference unitHealth;

    public void dealDamage(int damage)
    {
        unitHealth.Variable.ApplyChange(-damage);
    }
}
