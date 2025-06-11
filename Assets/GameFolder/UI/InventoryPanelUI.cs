using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelUI : MonoBehaviour
{
    [SerializeField] private List<IconPanelUI> icons;
    [SerializeField] private NewItemRuntimeSet runtimeSet;

    private void Start()
    {
        AddIconsToList();
    }

    /*
    public void DisplayIcons()
    {
        //Debug.Log("Called");
        int i = 0;
        foreach(IconPanelUI icon in icons)
        {
            if (i < runtimeSet.Items.Count && runtimeSet.Items[i] != null)
            {
                icon.item = runtimeSet.Items[i];
                icon.DisplayIcon();
                i++;
            }
        }
    }
    */

    public void DisplayIcons()
{
    int itemCount = runtimeSet.Items.Count;
    int iconCount = icons.Count;
    int minCount = Mathf.Min(itemCount, iconCount);

    // For each matching index, assign the item to the icon and update it.
    for (int i = 0; i < minCount; i++)
    {
        IconPanelUI icon = icons[i];
        icon.item = runtimeSet.Items[i];
        icon.DisplayIcon();
    }

    // Clear any remaining icons if there are more icons than items.
    for (int i = minCount; i < iconCount; i++)
    {
        IconPanelUI icon = icons[i];
        icon.item = null;
        icon.DisplayIcon();
    }

    // Optionally, handle the case where there are more items than icons.
    if (itemCount > iconCount)
    {
        Debug.LogWarning("There are more items in the runtime set than available icons. Some items won't be displayed.");
    }
}

    private void AddIconsToList()
    {
       icons = new List<IconPanelUI>(GetComponentsInChildren<IconPanelUI>()); 
    }
}
