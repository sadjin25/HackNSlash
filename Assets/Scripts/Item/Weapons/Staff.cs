using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon
{
    public Staff()
    {

    }

    public Staff(WeaponData _weaponData)
    {
        // Deep Cpy
        weaponData = _weaponData;
    }

    public override bool LootItem(Player player, PlayerInvHolder invHolder)
    {
        Staff toGet = new Staff(this.weaponData);

        if (player)
        {
            // TODO : make GetWeapon() func in player class
            player.equipmentHandler.weaponHandler.Loot(toGet.weaponData);
        }

        if (invHolder)
        {
            invHolder.AddItem(toGet.weaponData, 1);
        }

        Destroy(this.gameObject);

        return true;
    }
}
