using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvUIController : MonoBehaviour
{
    public DynamicInvDisplay chestInvPanel;
    public DynamicInvDisplay playerInvPanel;

    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayChestInv;
        PlayerInvHolder.OnPlayerInventoryDisplayRequested += DisplayPlayerInv;
    }

    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayChestInv;
        PlayerInvHolder.OnPlayerInventoryDisplayRequested -= DisplayPlayerInv;
    }

    private void Awake()
    {
        chestInvPanel.gameObject.SetActive(false);
        playerInvPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if ((playerInvPanel.gameObject.activeInHierarchy || chestInvPanel.gameObject.activeInHierarchy) && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            chestInvPanel.gameObject.SetActive(false);
            playerInvPanel.gameObject.SetActive(false);
        }
    }

    void DisplayChestInv(InventorySystem invToDisplay)
    {
        chestInvPanel.gameObject.SetActive(true);
        chestInvPanel.RefreshDynamicInv(invToDisplay);
    }

    void DisplayPlayerInv(InventorySystem invToDisplay)
    {
        playerInvPanel.gameObject.SetActive(true);
        playerInvPanel.RefreshDynamicInv(invToDisplay);
    }
}
