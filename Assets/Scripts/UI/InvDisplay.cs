using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InvDisplay : MonoBehaviour
{
    [SerializeField] OnMouseItemData onMouseItem;
    protected InventorySystem inventorySystem;
    protected Dictionary<InvSlotUI, InventorySlot> slotDict;

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InvSlotUI, InventorySlot> SlotDict => slotDict;

    protected virtual void Start()
    {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in SlotDict)
        {
            if (slot.Value == updatedSlot)
            {
                slot.Key.UpdateUISlot(updatedSlot);
            }
        }
    }

    public void SlotClicked(InvSlotUI clickedSlot)
    {

        // Clicked slot has an item && mouse doesn't have an item - pick up item.
        if (clickedSlot.AssignedInvSlot.ItemData != null && onMouseItem.AssignedInvSlot.ItemData == null)
        {
            // Holding Shift Key - Split items.
            onMouseItem.UpdateMouseSlot(clickedSlot.AssignedInvSlot);
            clickedSlot.ClearSlot();
            return;
        }

        // Clicked slot doesn't have an item && mouse does have an item - place item.
        if (clickedSlot.AssignedInvSlot.ItemData == null && onMouseItem.AssignedInvSlot.ItemData != null)
        {
            // Holding Shift Key - Split items.
            clickedSlot.AssignedInvSlot.AssignItem(onMouseItem.AssignedInvSlot);
            clickedSlot.UpdateUISlot();
            onMouseItem.ClearSlot();
            return;
        }

        // Both slot has an item
        // is item same? - combine(only if slot stack + dragged item stack <= maxStackSize, else take item from mouse).

        // if diffrent - swap items.

    }
}
