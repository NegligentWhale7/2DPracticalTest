using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += InventoryOnItemListChanged;
        RefreshInventoryItems();
    }

    private void InventoryOnItemListChanged()
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory.GetItems())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            var image = itemSlotRectTransform.Find("Image").GetComponent<UnityEngine.UI.Image>();
            image.sprite = item.GetSprite();
        }
    }

    private void OnDisable()
    {
        inventory.OnItemListChanged -= InventoryOnItemListChanged;
    }
}
