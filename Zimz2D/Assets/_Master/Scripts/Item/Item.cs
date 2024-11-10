using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Weapon,
        Armature,
        HealthPotion,
        Strawberries,
        Potatoes,
        Pumpkin,
        Aubergine,
        RogueMask
    }

    public ItemType itemType;
    public int amount = 1;
    public int itemSellPrice => GetSellPrice();

    public Sprite GetSprite()
    {
        return itemType switch
        {
            ItemType.Weapon => ItemAssets.Instance.WeaponSprite,
            ItemType.Armature => ItemAssets.Instance.ArmatureSprite,
            ItemType.Strawberries => ItemAssets.Instance.StrawberriesSprite,
            ItemType.Potatoes => ItemAssets.Instance.PotatoesSprite,
            ItemType.Pumpkin => ItemAssets.Instance.PumpkinSprite,
            ItemType.Aubergine => ItemAssets.Instance.AubergineSprite,
            ItemType.RogueMask => ItemAssets.Instance.RogueMaskSprite,
            _ => ItemAssets.Instance.HealthPotionSprite,
        };
    }

    public int GetSellPrice()
    {
        return itemType switch
        {
            ItemType.HealthPotion => 5,
            ItemType.Aubergine => 10,
            ItemType.Potatoes => 15,
            ItemType.Strawberries => 20,
            ItemType.Pumpkin => 25,
            ItemType.Weapon => 30,
            ItemType.Armature => 35,
            ItemType.RogueMask => 40,
            _ => 5,
        };
    }

    public bool isStackable()
    {
        switch (itemType)
        {
            case ItemType.HealthPotion:
            case ItemType.Aubergine:
            case ItemType.Potatoes:
            case ItemType.Strawberries:
            case ItemType.Pumpkin:
                return true;
            case ItemType.Weapon:
            case ItemType.Armature:
            case ItemType.RogueMask:
                return false;
            default:
                return false;
        }
    }
}
