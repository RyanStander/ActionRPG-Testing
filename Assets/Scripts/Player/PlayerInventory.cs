using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private WeaponSlotManager weaponSlotManager;

    public WeaponItem rightWeapon, leftWeapon;

    private void Awake()
    {
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start()
    {
        weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
        weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
    }
}
