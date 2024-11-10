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

    public void ShowSellableMoney()
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

            var shopItemInstance = itemSlotRectTransform.GetComponent<ShopItem>();

            // Asigna las propiedades específicas para cada instancia
            shopItemInstance.ItemImage.sprite = item.GetSprite();
            shopItemInstance.ItemAmount.SetText(item.amount > 1 ? item.amount.ToString() : "");
            shopItemInstance.ItemSellPrice.SetText(item.ItemSellPrice.ToString());

            // Asigna la función SellItem al botón del objeto instanciado
            shopItemInstance.SellButton.onClick.AddListener(() => SellItem(item));
            shopItemInstance.SellButton.onClick.AddListener(() => CheckUnpurchased(shopItemInstance));
        }
    }


    public void SellItem(Item item)
    {
        playerManager.CurrentMoney += item.ItemSellPrice;
        ShowSellableMoney();
        playerManager.Inventory.RemoveItem(item);
        DisplayItemInInventory();
        Debug.Log("Item sold: " + item.itemType);
    }

    public void CheckUnpurchased(ShopItem shopItem)
    {
        var item = shopItem.Item;
        if(item != null) item.isPurchased = false;
    }
}
