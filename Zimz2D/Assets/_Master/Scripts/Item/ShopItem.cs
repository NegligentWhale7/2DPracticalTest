using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] PurchableItem item;
    [SerializeField] TextMeshProUGUI costText;

    private Inventory inventory;
    private Item itemToAdd;

    public PurchableItem Item => item;

    public enum PurchableItemType
    {
        Weapon,
        Armature,
        HealthPotion,
        Strawberries,
        Potatoes,
        Pumpkin,
        Aubergine,
    }

    [SerializeField] PurchableItemType itemType;

    private void Awake()
    {
        costText.SetText(item.itemPrice.ToString());
    }

    public void AddPurchasedItem()
    {
        itemToAdd = new Item
        {
            itemType = (Item.ItemType)itemType,
            amount = 1
        };
       playerManager.Inventory.AddItem(itemToAdd);
    }
}
