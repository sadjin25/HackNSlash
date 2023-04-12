using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IEquipment
{
    [SerializeField] protected WeaponData weaponData;

    public abstract bool LootItem(Player player, InventoryHolder invHolder);
}
