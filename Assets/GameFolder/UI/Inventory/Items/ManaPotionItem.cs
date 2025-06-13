using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotionItem : ItemBaseClass
{
    public FloatVariable Mana;
    public FloatReference amount;
    public override void Use()
    {
        if(stackSize.Value > 0)
        {
            Mana.ApplyChange(amount);
            stackSize.ApplyChange(-1);
            Remove();
        }
    }
}
