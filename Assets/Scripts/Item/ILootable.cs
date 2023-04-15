using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILootable
{
    public abstract bool LootItem(Player player, InventoryHolder invHolder);
}
