using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;
    public List<InventorySlot> InventorySlots => inventorySlots;

    public int CurItemNums => inventorySlots.Count;
    private int maxInventorySize;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);
        maxInventorySize = size;

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddItem(ItemData _itemData, int amountToAdd)
    {
        // WARNING : if amountToAdd is over itemData's maxStackSize, then curItemNums + amountToAdd / _itemData.maxStackSize + alpha. 
        if (CurItemNums + 1 <= maxInventorySize)
        {
            inventorySlots[0] = new InventorySlot(_itemData, amountToAdd);
        }
        return true;
    }

}
