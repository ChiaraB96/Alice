using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    private Dictionary<InventoryItemData, InventoryItem> _itemDictionary;
    public List<InventoryItem> inventory;

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();

        Instance = this;
    }
    /*public InventoryItem Get(InventoryItemData itemData)
    {
        if(_itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }*/

    public void Add(InventoryItemData itemData)
        {
            if(_itemDictionary.TryGetValue(itemData, out InventoryItem value))
            {
                value.AddToStack();
            }
            else
            {
                InventoryItem newItem = new InventoryItem(itemData);
                inventory.Add(newItem);
                _itemDictionary.Add(itemData, newItem);
            }
        }
        public void Remove(InventoryItemData itemData)
        {
            if(_itemDictionary.TryGetValue(itemData, out InventoryItem value))
            {
                value.RemoveFromStack();

                if(value.stackSize == 0)
                {
                    inventory.Remove(value);
                    _itemDictionary.Remove(itemData);
                }
            }
        }
}
