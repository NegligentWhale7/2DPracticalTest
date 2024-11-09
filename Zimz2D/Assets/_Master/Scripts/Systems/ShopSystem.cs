using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] TextMeshProUGUI moneyText;

    public void ShowMoney()
    {
        moneyText.text = playerManager.CurrentMoney.ToString();
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
}
