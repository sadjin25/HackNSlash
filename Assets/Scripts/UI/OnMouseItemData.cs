using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class OnMouseItemData : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI itemCount;
    public InventorySlot AssignedInvSlot;

    void Awake()
    {
        itemSprite.color = Color.clear;
        itemCount.text = "";
        AssignedInvSlot = new InventorySlot();
    }

    void Update()
    {
        if (AssignedInvSlot.ItemData != null)
        {
            transform.position = Mouse.current.position.ReadValue();

            if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObj())
            {
                ClearSlot();
            }
        }
    }

    public void ClearSlot()
    {
        AssignedInvSlot.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssignedInvSlot.AssignItem(invSlot);
        itemSprite.sprite = invSlot.ItemData.sprite;
        itemCount.text = invSlot.StackSize.ToString();
        itemSprite.color = Color.white;
    }

    public static bool IsPointerOverUIObj()
    {
        PointerEventData eventDataCurPos = new PointerEventData(EventSystem.current);
        eventDataCurPos.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurPos, results);
        return results.Count > 0;
    }
}
