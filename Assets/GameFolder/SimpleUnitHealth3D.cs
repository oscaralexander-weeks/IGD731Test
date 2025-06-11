using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleUnitHealth3D : MonoBehaviour
{
    public FloatVariable HP;
    public FloatReference startingHP;

    public UnityEvent deathEvent;
    public UnityEvent damageEvent;
    public UnityEvent itemEvent;

    public bool resetHP;

    private void Start()
    {
        if (resetHP)
        {
            HP.SetValue(startingHP.Value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();

        ItemMono item = other.gameObject.GetComponent<ItemMono>();

        if(damage != null)
        {
            damage.dealDamage(20);
            damageEvent.Invoke();
        }

        if(HP.Value <= 0.0f)
        {
            deathEvent.Invoke();
        }

        if(item != null)
        {
            itemEvent.Invoke();
        }
    }

}
