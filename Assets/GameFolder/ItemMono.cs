using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemMono : MonoBehaviour
{
    public ItemVariable item;
    public ItemRunTimeSet itemRuntimeSet;

    public void AddItem()
    {
        itemRuntimeSet.Add(item);
    }
}
