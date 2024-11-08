using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;

    private enum ItemType
    {
        Weapon,
        Armature,
        HealthPotion,
        Strawberries,
        Potatoes,
        Pumpkin,
        Aubergine,
    }
    [SerializeField] private ItemType type;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        item = new Item();
        item.itemType = (Item.ItemType)type;
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem()
    {
        SetItem(item);
        //Debug.Log(item.itemType);
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}