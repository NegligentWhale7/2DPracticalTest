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

        //AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Aubergine, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Armature, amount = 1 });
        //Debug.Log(items.Count);
    }

    public void AddItem(Item item)
    {
        if(item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in items)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount ++;
                    itemAlreadyInInventory = true;
                    Debug.Log("Item already in inventory " + item.amount);
                }
            }
            if(!itemAlreadyInInventory)
            {
                items.Add(item);
                Debug.Log("New stackable item " + item.amount);
            }
        }
        else
        {
            items.Add(item);
            Debug.Log("New item " + item.amount);
        }

        OnItemListChanged?.Invoke();
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public void RemoveItem(Item item)
    {
        if(item.IsStackable())
        {
            Item itemToRemove = null;
            foreach (Item inventoryItem in items)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount--;
                    if (inventoryItem.amount == 0)
                    {
                        itemToRemove = inventoryItem;
                    }
                }
            }
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
            }
        }
        else
        {
            items.Remove(item);
        }
        OnItemListChanged?.Invoke();
    }

    public void UseItem(Item item, PlayerManager playerManager)
    {
        bool isEquipably = item.GetIsEquipable();
        bool isAVariant = item.GetIsAVariant();

        if (isEquipably)
        {
            if (item.itemType == Item.ItemType.RogueHair)
            {
                playerManager.EquipRogueHair();
            }
            else if (item.itemType == Item.ItemType.RogueMask)
            {
                playerManager.EquipRogueMask();
            }
            if(item.itemType == Item.ItemType.Weapon)
            {
                playerManager.CanAttack = true;
                playerManager.EquipSword();
            }
        }
        if(isAVariant)
        {
            playerManager.ChangeToVariant();
        }
        if(item.itemType == Item.ItemType.HealthPotion)
        {
            playerManager.Heal(5);
            RemoveItem(item);
        }
    }
}
