using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] PurchableItem item;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] bool isSelling = false;
    [Header("Sell Settings")]
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemAmount;
    [SerializeField] Button sellButton;

    private Inventory inventory;
    private Item itemToAdd;

    public PurchableItem Item => item;
    public Image ItemImage => itemImage;
    public TextMeshProUGUI ItemAmount => itemAmount;
    public TextMeshProUGUI ItemSellPrice => costText;
    public Button SellButton => sellButton;

    public enum PurchableItemType
    {
        Weapon,
        Armature,
        HealthPotion,
        Strawberries,
        Potatoes,
        Pumpkin,
        Aubergine,
        RogueMask,
        RogueHair,
        VariantC
    }

    [SerializeField] PurchableItemType itemType;

    private void Awake()
    {
        if(!isSelling) costText.SetText("$"+item.itemPrice.ToString());
        playerManager = FindObjectOfType<PlayerManager>();
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
