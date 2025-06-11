using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ItemBaseClass : MonoBehaviour, ICollectible
{
    public NewItemSO itemData;
    public FloatVariable stackSize;
    public NewItemRuntimeSet runtimeSet;

    //test 
    public UnityEvent onCollection;
    public UnityEvent onDepletion;

    public abstract void Use();

    public void Collect()
    {
        Debug.Log("collected");
        runtimeSet.Add(this);
        stackSize.ApplyChange(1);
        onCollection?.Invoke();
    }

    public void Remove()
    {
        onDepletion?.Invoke();
        if(stackSize.Value < 1)
        {
            runtimeSet.Remove(this);
            onDepletion?.Invoke();
        }
    }
}
