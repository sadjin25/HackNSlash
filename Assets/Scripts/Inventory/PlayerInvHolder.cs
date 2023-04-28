using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInvHolder : InventoryHolder
{
    [SerializeField] protected int playerInvSize;
    [SerializeField] protected InventorySystem playerInventorySystem;

    public InventorySystem PlayerInventorySystem => playerInventorySystem;

    public static UnityAction<InventorySystem> OnPlayerInventoryDisplayRequested;

    protected override void Awake()
    {
        base.Awake();

        playerInventorySystem = new InventorySystem(playerInvSize);
    }

    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            OnPlayerInventoryDisplayRequested?.Invoke(playerInventorySystem);
        }
    }

    public bool AddItem(ItemData data, int amount)
    {
        if (inventorySystem.AddItem(data, amount))
        {
            return true;
        }
        else if (playerInventorySystem.AddItem(data, amount))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
