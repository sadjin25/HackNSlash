using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHandler : MonoBehaviour
{
    // Weapon
    private WeaponHandler weaponHandler;

    // TEMPORARY WEAPON INSTANCE.
    private Weapons weaponTemp = new Weapons();

    void Start()
    {
        weaponHandler = new WeaponHandler(weaponTemp);
    }

    public void Attack()
    {
        weaponHandler.Attack();
    }
}
