using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipment : ILootable
{
    new public bool LootItem(Player player);
}
