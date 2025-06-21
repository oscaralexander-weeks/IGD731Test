using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private NewItemRuntimeSet itemRuntimeSet;

    public void OnItem1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UseItem(0);
        }
    }

    public void OnItem2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UseItem(1);
        }
    }

    public void UseItem(int index)
    {
        if (itemRuntimeSet != null && itemRuntimeSet.Items.Count > 0)
        {
            itemRuntimeSet.Items[index].Use();
        }

    }
}
