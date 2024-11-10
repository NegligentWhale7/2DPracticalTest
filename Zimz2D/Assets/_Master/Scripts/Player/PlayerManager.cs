using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private UIBarItem healthBar;
    [SerializeField] UIInventory uiInventory;
    [SerializeField] Canvas deathCanvas;
    [SerializeField] TextMeshProUGUI moneyText;
    [Header("Skins")]
    [SerializeField] PlayerAnimationsManager playerAnimationsManager;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject rogueMask;
    [SerializeField] private GameObject rogueHair;
    [SerializeField] private SpriteRenderer skinA;
    [SerializeField] private SpriteRenderer skinC;
    [SerializeField] private GameObject swordAVariant, swordCVariant;
    [SerializeField] private Animator animatorA;
    [SerializeField] private Animator animatorC;

    private Inventory inventory;
    private PlayerInputManager playerInputManager;
    private float currentHealth;
    private int currentMoney = 0;
    private bool canAttack = false;

    public Inventory Inventory { get => inventory; }
    public int CurrentMoney { get => currentMoney; set => currentMoney = value; }
    public bool CanAttack { get => canAttack; set => canAttack = value; }

    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        UpdateMoney();
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
        playerAnimationsManager.Weapon = swordCVariant;
       // swordAVariant.SetActive(false);
        //swordCVariant.SetActive(true);
    }

    [ContextMenu("BackToOriginal")]
    public void BackToOriginal()
    {
        skinA.enabled = true;
        skinC.enabled = false;
        playerAnimationsManager.Animator = animatorA;
        animatorA.enabled = true;
        animatorC.enabled = false;
        playerAnimationsManager.Weapon = swordAVariant;
        //swordAVariant.SetActive(true);
        //swordCVariant.SetActive(false);
    }

    public void EquipRogueMask()
    {
        rogueMask.SetActive(true);
        rogueHair.SetActive(false);
    }

    public void EquipRogueHair()
    {
        rogueMask.SetActive(false);
        rogueHair.SetActive(true);
    }

    public void EquipSword()
    {
        sword.SetActive(true);
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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            deathCanvas.enabled = true;
        }
        healthBar.DisplayBarValue(currentHealth, maxHealth);
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.DisplayBarValue(currentHealth, maxHealth);
    }

    public void Attack()
    {
        if(!canAttack) return;
        if(playerInputManager.AttackInput) playerAnimationsManager.SetAttackAnimation();
    }

    public void UpdateMoney()
    {
        moneyText.text = "$"+currentMoney.ToString();
    }
}
