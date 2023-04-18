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
        Debug.Log("SlotClicked");
    }
}
