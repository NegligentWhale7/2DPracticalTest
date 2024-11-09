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
    }

    public ItemType itemType;
    public int amount = 1;

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
            _ => ItemAssets.Instance.HealthPotionSprite,
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
                return false;
            default:
                return false;
        }
    }
}
