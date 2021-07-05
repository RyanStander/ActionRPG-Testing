using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    private WeaponHolderSlot leftHandSlot, rightHandSlot;

    private DamageCollider leftHandDamageCollider, rightHandDamageCollider;
    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponHolderSlot in weaponHolderSlots)
        {
            if (weaponHolderSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponHolderSlot;
            }
            else if (weaponHolderSlot.isRightHandSlot)
            {
                rightHandSlot = weaponHolderSlot;
            }
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem,bool isLeft)
    {
        if (isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
            if (leftHandSlot != null)
                LoadLeftWeaponDamageCollider();
        }
        else
        {
            rightHandSlot.LoadWeaponModel(weaponItem);
            if (rightHandSlot != null)
                LoadRightWeaponDamageCollider();
        }
    }

    #region Damage Colliders
    private void LoadLeftWeaponDamageCollider()
    {
        if (leftHandSlot != null&& leftHandSlot.currentWeaponModel!=null)
        leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    private void LoadRightWeaponDamageCollider()
    {
        if (rightHandSlot != null && rightHandSlot.currentWeaponModel != null)
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    public void OpenRightHandDamageCollider()
    {
        rightHandDamageCollider.EnableDamageCollider();
    }

    public void OpenLeftHandDamageCollider()
    {
        leftHandDamageCollider.EnableDamageCollider();
    }

    public void CloseRightHandDamageCollider()
    {
        rightHandDamageCollider.DisableDamageCollider();
    }

    public void CloseLeftHandDamageCollider()
    {
        leftHandDamageCollider.DisableDamageCollider();
    }

    #endregion
}
