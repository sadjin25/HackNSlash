using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
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
        if (IsContaining(_itemData, out List<InventorySlot> invSlots))  // Chk if item is already in invSys.
        {
            foreach (var slot in invSlots)
            {
                if (slot.isStackAvailableToAdd(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }

        else if (HasFreeSlot(out InventorySlot freeSlot))   // Find First Empty Slot.
        {
            freeSlot.UpdateInvSlot(_itemData, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }

        return false;
    }

    public bool IsContaining(ItemData toAdd, out List<InventorySlot> invSlots)
    {
        invSlots = InventorySlots.Where(i => i.ItemData == toAdd).ToList();

        return invSlots == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);

        return freeSlot == null ? false : true;
    }
}
