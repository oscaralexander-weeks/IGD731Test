using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionItem : ItemBaseClass
{
    [SerializeField] private FloatVariable HP;
    public FloatReference amount;
    public override void Use()
    {
        Debug.Log("use");
        if(stackSize.Value > 0 && HP.Value < 100)
        {
            HP.ApplyChange(amount);
            stackSize.ApplyChange(-1);
            Remove();
        }
    }

    
}
