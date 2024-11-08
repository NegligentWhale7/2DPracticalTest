using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private UIBarItem healthBar;
    [SerializeField] UIInventory uiInventory;

    private Inventory inventory;
    private float currentHealth;

    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.DisplayBarValue(currentHealth, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
