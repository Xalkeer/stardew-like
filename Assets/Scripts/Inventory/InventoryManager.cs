using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxItems = 10;

    [SerializeField]
    private List<AllItems> items = new List<AllItems>();

    public bool AddItem(AllItems item)
    {
        if (items.Count < maxItems)
        {
            items.Add(item);
            Debug.Log("Item added. Current item count: " + items.Count);
            return true;
        }
        else
        {
            Debug.Log("Inventory full. Cannot add more items.");
            return false;
        }
    }
}