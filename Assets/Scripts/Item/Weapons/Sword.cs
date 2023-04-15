using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public Sword()
    {

    }

    public Sword(WeaponData _weaponData)
    {
        // Deep Cpy
        weaponData = _weaponData;
    }

    public override bool LootItem(Player player, InventoryHolder invHolder)
    {
        Sword toGet = new Sword(this.weaponData);

        if (player)
        {
            // TODO : make GetWeapon() func in player class
            player.equipmentHandler.weaponHandler.Loot(toGet.weaponData);
        }

        if (invHolder)
        {
            invHolder.InventorySystem.AddItem(toGet.weaponData, 1);
        }

        Destroy(this.gameObject);

        return true;
    }
}
