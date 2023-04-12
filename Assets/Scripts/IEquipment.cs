using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipment : ILootable
{
    new public abstract bool LootItem(Player player, InventoryHolder invHolder);
}
