using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
   public enum ItemType
    {
        //Coin,
        Weapon,
        Armature,
        HealthPotion,
        Strawberries,
        Potatoes,
        Pumpkin,
        Aubergine,
    }

    public ItemType itemType;
    public int amount;

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
}
