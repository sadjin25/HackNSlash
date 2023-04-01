using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHandler : MonoBehaviour
{
    // Weapon
    private WeaponHandler weaponHandler;


    void Start()
    {
        weaponHandler = new WeaponHandler();
    }

    public void Attack()
    {
        weaponHandler.Attack();
    }
}
