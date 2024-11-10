using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantC : MonoBehaviour
{
    [SerializeField] PlayerAnimationsManager playerManager;

    public void DisableAttackAnim()
    {
        playerManager.DisableAttackAnimation();
    }
}
