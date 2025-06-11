using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class IconPanelUI : MonoBehaviour
{
    public ItemBaseClass item;

    public TextMeshProUGUI stackSize;
    public TextMeshProUGUI itemName;

    private void Start()
    {
        item = null;
        itemName.text = string.Empty;
        stackSize.text = string.Empty;
    }

    public void DisplayIcon()
    {
        if(item != null && item.stackSize.Value > 0)
        {
            itemName.text = item.itemData.itemName;
            stackSize.text = item.stackSize.Value.ToString();
        }
        else
        {
            item = null;
            itemName.text = string.Empty;
            stackSize.text = string.Empty;
        }
    }
}
