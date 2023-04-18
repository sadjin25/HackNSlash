using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInvDisplay : InvDisplay
{
    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InvSlotUI[] slots;

    protected override void Start()
    {
        base.Start();

        if (inventoryHolder != null)
        {
            inventorySystem = inventoryHolder.InventorySystem;
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        else
        {
            Debug.LogWarning($"No Inv assigned to {this.gameObject}");
        }

        AssignSlot(inventorySystem);
    }

    public override void AssignSlot(InventorySystem invToDisplay)
    {
        slotDict = new Dictionary<InvSlotUI, InventorySlot>();

        if (slots.Length != inventorySystem.CurItemNums)
        {
            Debug.Log($"Inv Slots out of sync on {this.gameObject}");
        }

        for (int i = 0; i < inventorySystem.CurItemNums; i++)
        {
            slotDict.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init(inventorySystem.InventorySlots[i]);
        }
    }

}
