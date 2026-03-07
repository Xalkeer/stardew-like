using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxItems = 10;
    
    public Dictionary<AllItems, int> itemDictionary = new Dictionary<AllItems, int>();

    private void Start()
    {
        DictionaryInitiate();
        DisplayInventory();
    }
    
    public void DisplayInventory()
    {
        Debug.Log("Inventory:");
        foreach (var item in itemDictionary)
        {
            Debug.Log("- " + item.Key + ": " + item.Value);
        }
    }

    public void AddValue(int newValue, AllItems item)
    {
        itemDictionary[item] += newValue;
    }
    public void RemoveValue(int newValue, AllItems item)
    {
        if (itemDictionary[item] - newValue < 0)
        {
            Debug.Log("Not enough " + item + " to remove.");
        }else
        {
            itemDictionary[item] -= newValue;
        }
    }



    public void DictionaryInitiate()
    {
        itemDictionary.Add( AllItems.Wood,0);
        itemDictionary.Add( AllItems.Stone,0);
        itemDictionary.Add( AllItems.Iron,0);
        itemDictionary.Add( AllItems.Gold,0);
        itemDictionary.Add( AllItems.Diamond,0);
    }
    


}