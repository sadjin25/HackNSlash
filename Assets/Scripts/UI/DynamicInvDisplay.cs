using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicInvDisplay : InvDisplay
{
    [SerializeField] protected InvSlotUI slotPrefab;

    protected override void Start()
    {
        base.Start();
    }

    private void OnDestroy()
    {
        InventorySystem.OnInventorySlotChanged -= UpdateSlot;
    }

    public void RefreshDynamicInv(InventorySystem invToDisplay)
    {
        ClearSlots();
        inventorySystem = invToDisplay;
        if (inventorySystem != null)
        {
            InventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        AssignSlot(invToDisplay);
    }

    public override void AssignSlot(InventorySystem invToDisplay)
    {
        ClearSlots();
        slotDict = new Dictionary<InvSlotUI, InventorySlot>();
        if (invToDisplay == null)
        {
            return;
        }

        for (int i = 0; i < invToDisplay.CurItemNums; i++)
        {
            var uiSlot = Instantiate(slotPrefab, transform);
            slotDict.Add(uiSlot, invToDisplay.InventorySlots[i]);
            uiSlot.Init(inventorySystem.InventorySlots[i]);
            uiSlot.UpdateUISlot();
        }

    }

    private void ClearSlots()
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }

        if (slotDict != null)
        {
            slotDict.Clear();
        }
    }
}
