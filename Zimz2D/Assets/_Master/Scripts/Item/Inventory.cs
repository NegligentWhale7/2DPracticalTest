using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public Action OnItemListChanged;
    public List<Item> items = new();

    public Inventory()
    {
        items = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Aubergine, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Armature, amount = 1 });
        //Debug.Log(items.Count);
    }

    public void AddItem(Item item)
    {
        if(item.isStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in items)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount ++;
                    itemAlreadyInInventory = true;
                    //Debug.Log("Item already in inventory " + item.amount);
                }
            }
            if(!itemAlreadyInInventory)
            {
                items.Add(item);
                //Debug.Log("New stackable item " + item.amount);
            }
        }
        else
        {
            items.Add(item);
            //Debug.Log("New item " + item.amount);
        }

        OnItemListChanged?.Invoke();
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
