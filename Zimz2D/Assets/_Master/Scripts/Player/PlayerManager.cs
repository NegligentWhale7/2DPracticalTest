using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private UIBarItem healthBar;
    [SerializeField] UIInventory uiInventory;
    [Header("Skins")]
    [SerializeField] PlayerAnimationsManager playerAnimationsManager;
    [SerializeField] private SpriteRenderer skinA;
    [SerializeField] private SpriteRenderer skinC;
    [SerializeField] private Animator animatorA;
    [SerializeField] private Animator animatorC;

    private Inventory inventory;
    private float currentHealth;
    private int currentMoney = 10000;

    public Inventory Inventory { get => inventory; }
    public int CurrentMoney { get => currentMoney; set => currentMoney = value; }

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

    [ContextMenu("ChangeToC")]
    public void ChangeToVariant()
    {
        skinA.enabled = false;
        skinC.enabled = true;
        playerAnimationsManager.Animator = animatorC;
        animatorA.enabled = false;
        animatorC.enabled = true;
    }

    [ContextMenu("BackToOriginal")]
    public void BackToOriginal()
    {
        skinA.enabled = true;
        skinC.enabled = false;
        playerAnimationsManager.Animator = animatorA;
        animatorA.enabled = true;
        animatorC.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.gameObject.SetActive(false);
            //Debug.Log(itemWorld.GetItem());
            //itemWorld.DestroySelf();
        }
    }
}
