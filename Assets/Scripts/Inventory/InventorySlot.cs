using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
        stackSize = 0;
    }

    public void AssignItem(InventorySlot invSlot)
    {
        if (itemData == invSlot.ItemData)
        {
            AddToStack(invSlot.StackSize);
        }

        else
        {
            itemData = invSlot.ItemData;
            stackSize = 0;
            AddToStack(invSlot.StackSize);
        }
    }

    public void UpdateInvSlot(ItemData data, int amount)
    {
        itemData = data;
        stackSize = amount;
    }

    public bool isStackAvailableToAdd(int amountToAdd, out int amountRemain)
    {
        amountRemain = itemData.maxStackSize - stackSize - amountToAdd;
        return isStackAvailableToAdd(amountToAdd);
    }

    public bool isStackAvailableToAdd(int amountToAdd)
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
