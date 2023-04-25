using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInv : InventoryHolder, IInteractable
{
    public UnityAction<IInteractable> OnInteractionComplete { get; set; }

    public bool Interact(Interactor interactor)
    {
        OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
        return true;
    }

    public void EndInteraction()
    {

    }
}
