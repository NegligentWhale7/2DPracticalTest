using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIInventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Canvas inventoryCanvas;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;

    public void OpenInventoryCanvas()
    {
        inventoryCanvas.enabled = true;
    }

    public void CloseInventoryCanvas()
    {
        inventoryCanvas.enabled = false;
    }

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
            //TextMeshProUGUI text = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI text = itemSlotRectTransform.GetComponentInChildren<TextMeshProUGUI>();
            if (item.amount > 1)  text.SetText(item.amount.ToString());
            else text.SetText("");
        }
    }

    private void OnDisable()
    {
        inventory.OnItemListChanged -= InventoryOnItemListChanged;
    }
}
