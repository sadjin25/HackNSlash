using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHandler : MonoBehaviour
{
    // Weapon
    public WeaponHandler weaponHandler;


    void Awake()
    {
        weaponHandler = gameObject.AddComponent<WeaponHandler>();
    }

    public void Attack()
    {
        weaponHandler.Attack();
    }
}
