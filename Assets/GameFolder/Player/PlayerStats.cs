using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public FloatVariable HP;



    public void TakeDamage(int damage)
    {
        if(HP == null)
        {
            Debug.LogWarning("HP not assigned");
        }

        HP.ApplyChange(-damage);
    }
}
