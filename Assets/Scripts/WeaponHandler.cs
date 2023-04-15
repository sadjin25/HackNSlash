using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    private WeaponData curWeapon;


    public void Attack()
    {
        // Use WeaponBase instance's curWeaponStats.damage/cooldown 
    }

    public void Loot(WeaponData weaponToGet)
    {
        curWeapon = weaponToGet;
    }
}
