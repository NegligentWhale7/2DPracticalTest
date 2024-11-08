using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion
    }

    public Transform pfItemWorld;
    //public Sprite CoinSprite;
    public Sprite HealthPotionSprite;
    public Sprite WeaponSprite;
    public Sprite ArmatureSprite;
    public Sprite StrawberriesSprite;
    public Sprite PotatoesSprite;
    public Sprite PumpkinSprite;
    public Sprite AubergineSprite;

}
