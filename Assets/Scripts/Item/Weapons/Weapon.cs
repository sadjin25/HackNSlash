using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, ILootable
{
    [SerializeField] protected WeaponData weaponData;

    public virtual bool LootItem(Player player, PlayerInvHolder invHolder)
    {
        if (player)
        {
            // TODO : make GetWeapon() func in player class
            player.equipmentHandler.weaponHandler.Loot(this.weaponData);
        }

        if (invHolder)
        {
            invHolder.AddItem(this.weaponData, 1);
        }

        Destroy(this.gameObject);

        return true;
    }
}
