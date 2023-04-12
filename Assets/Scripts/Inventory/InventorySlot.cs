using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int stackSize;

    public ItemData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlot(ItemData _itemData, int amount)
    {
        itemData = _itemData;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public bool isStackAvailable(int amountToAdd, out int amountRemain)
    {
        amountRemain = itemData.maxStackSize - stackSize - amountToAdd;
        return isStackAvailable(amountToAdd);
    }

    public bool isStackAvailable(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemData.maxStackSize)
        {
            return true;
        }

        return false;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }
}
