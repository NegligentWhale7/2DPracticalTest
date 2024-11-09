using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Purchable Item", menuName = "Inventory System/Items/Purchable Item")]
public class PurchableItem : ScriptableObject
{
    public string itemName;
    public int itemPrice;
    public bool canBuyMultiple = false;
    public bool isPurchased = false;
    public bool isEquipped = false;
}
