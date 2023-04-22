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
        bool isShiftPressed = Keyboard.current.leftShiftKey.isPressed;

        // Clicked slot has an item && mouse doesn't have an item - pick up item.
        if (clickedSlot.AssignedInvSlot.ItemData != null && onMouseItem.AssignedInvSlot.ItemData == null)
        {
            // Holding Shift Key - Split items.
            if (isShiftPressed)
            {
                onMouseItem.UpdateMouseSlot(new InventorySlot(clickedSlot.AssignedInvSlot.ItemData, 1));
                clickedSlot.AssignedInvSlot.RemoveFromStack(1);
                if (clickedSlot.AssignedInvSlot.StackSize > 0)
                {
                    clickedSlot.UpdateUISlot();

                }
                else
                {
                    clickedSlot.ClearSlot();
                }

                return;
            }
            else
            {
                onMouseItem.UpdateMouseSlot(clickedSlot.AssignedInvSlot);
                clickedSlot.ClearSlot();
                return;
            }
        }

        // Clicked slot doesn't have an item && mouse does have an item - place item.
        if (clickedSlot.AssignedInvSlot.ItemData == null && onMouseItem.AssignedInvSlot.ItemData != null)
        {
            // Holding Shift Key - Split items.
            if (isShiftPressed)
            {
                onMouseItem.AssignedInvSlot.RemoveFromStack(1);
                clickedSlot.AssignedInvSlot.UpdateInvSlot(onMouseItem.AssignedInvSlot.ItemData, 1);
                clickedSlot.UpdateUISlot();

                if (onMouseItem.AssignedInvSlot.StackSize > 0)
                {
                    onMouseItem.UpdateMouseSlot();
                }
                else
                {
                    onMouseItem.ClearSlot();
                }
                return;
            }
            else
            {
                clickedSlot.AssignedInvSlot.AssignItem(onMouseItem.AssignedInvSlot);
                clickedSlot.UpdateUISlot();
                onMouseItem.ClearSlot();
                return;
            }

        }

        // Both slot has an item
        if (clickedSlot.AssignedInvSlot.ItemData != null && onMouseItem.AssignedInvSlot.ItemData != null)
        {
            // is item same? - combine(only if slot stack + dragged item stack <= maxStackSize, else take item from mouse).
            if (clickedSlot.AssignedInvSlot.ItemData == onMouseItem.AssignedInvSlot.ItemData)
            {
                bool isOkToAdd = clickedSlot.AssignedInvSlot.isStackAvailableToAdd(onMouseItem.AssignedInvSlot.StackSize, out int remainingSpace);
                if (isOkToAdd) // Add At Once.
                {
                    clickedSlot.AssignedInvSlot.AddToStack(onMouseItem.AssignedInvSlot.StackSize);
                    clickedSlot.UpdateUISlot();
                    onMouseItem.ClearSlot();
                }

                else
                {
                    if (remainingSpace <= 0) // No Enough Space To Add, just Swap Slots.
                    {
                        SwapClickedSlot(clickedSlot);
                        return;
                    }
                    // Else, reduce OnMouseItem's stack, and add.
                    int remainingInMouse = onMouseItem.AssignedInvSlot.StackSize - remainingSpace;

                    clickedSlot.AssignedInvSlot.AddToStack(remainingSpace);
                    clickedSlot.UpdateUISlot();

                    onMouseItem.ClearSlot();
                    onMouseItem.UpdateMouseSlot(new InventorySlot(onMouseItem.AssignedInvSlot.ItemData, remainingInMouse));
                }
            }

            // if diffrent - swap items.
            else
            {
                SwapClickedSlot(clickedSlot);
                return;
            }
        }

    }

    private void SwapClickedSlot(InvSlotUI clickedSlot)
    {
        var temp = new InventorySlot(onMouseItem.AssignedInvSlot.ItemData, onMouseItem.AssignedInvSlot.StackSize);
        onMouseItem.ClearSlot();
        onMouseItem.UpdateMouseSlot(clickedSlot.AssignedInvSlot);

        clickedSlot.ClearSlot();
        clickedSlot.AssignedInvSlot.AssignItem(temp);
        clickedSlot.UpdateUISlot();
    }
}
