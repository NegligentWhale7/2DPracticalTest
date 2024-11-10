using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] TextMeshProUGUI moneyBuyText;
    [SerializeField] TextMeshProUGUI moneySellText;

    [SerializeField] private Transform stockContainer;
    [SerializeField] private Transform itemStockTemplate;

    public void ShowMoney()
    {
        moneyBuyText.text = playerManager.CurrentMoney.ToString();
    }

    public void ShowMoneySell()
    {
        moneySellText.text = playerManager.CurrentMoney.ToString();
    }

    public void PurchaseItem(GameObject itemPref)
    {
        var shopItem = itemPref.GetComponent<ShopItem>();
        var item = shopItem.Item;
        if (playerManager.CurrentMoney < item.itemPrice) return;
        if (item.isPurchased) return;

        playerManager.CurrentMoney -= item.itemPrice;
        if(!item.canBuyMultiple) item.isPurchased = true;
        shopItem.AddPurchasedItem();
        Debug.Log("Item purchased: " + item.itemName);
    }

    public void EquipItem(PurchableItem item)
    {
        if (!item.isPurchased)
        {
            Debug.Log("Item is not purchased yet");
            return;
        }

        if (item.isEquipped)
        {
            Debug.Log("Item is already equipped");
            return;
        }

        item.isEquipped = true;
        Debug.Log("Item equipped: " + item.itemName);
    }

    public void DisplayItemInInventory()
    {
        foreach (Transform child in stockContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in playerManager.Inventory.GetItems())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemStockTemplate, stockContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            var shopItem = itemStockTemplate.GetComponent<ShopItem>();
            var image = shopItem.ItemImage;
            image.sprite = item.GetSprite();
            var text = shopItem.ItemAmount;
            if (item.amount > 1) text.SetText(item.amount.ToString());
            else text.SetText("");
            var sellPrice = shopItem.ItemSellPrice;
            sellPrice.SetText(item.itemSellPrice.ToString());
        }
    }

    public void SellItem(Item item)
    {
        playerManager.CurrentMoney += item.itemSellPrice;
        playerManager.Inventory.RemoveItem(item);
    }
}
