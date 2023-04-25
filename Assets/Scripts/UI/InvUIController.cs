using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvUIController : MonoBehaviour
{
    public DynamicInvDisplay invPanel;

    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInv;
    }

    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInv;
    }

    private void Update()
    {
        if (invPanel.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            invPanel.gameObject.SetActive(false);
        }
    }

    void DisplayInv(InventorySystem invToDisplay)
    {
        invPanel.gameObject.SetActive(true);
        invPanel.RefreshDynamicInv(invToDisplay);
    }
}
