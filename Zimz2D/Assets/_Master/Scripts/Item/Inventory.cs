using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public List<Item> items = new();

    public Inventory()
    {
        items = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Aubergine, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Armature, amount = 1 });
        Debug.Log(items.Count);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
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
