using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvSlotUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemCnt;
    [SerializeField] private Image itemSprite;
    [SerializeField] private InventorySlot assignedInvSlot;

    private Button button;

    public InventorySlot AssignedInvSlot => assignedInvSlot;
    public InvDisplay ParentDisplay { get; private set; }

    private void Awake()
    {
        ClearSlot();

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        //GetComponentInParent()
        ParentDisplay = transform.parent.GetComponent<InvDisplay>();
    }

    public void ClearSlot()
    {
        assignedInvSlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCnt.text = "";
    }

    public void Init(InventorySlot slot)
    {
        assignedInvSlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot)
    {
        if (slot.ItemData != null)
        {
            itemSprite.sprite = slot.ItemData.sprite;
            itemSprite.color = Color.white;

            if (slot.StackSize > 1)
            {
                itemCnt.text = slot.StackSize.ToString();
            }
            else
            {
                itemCnt.text = "";
            }
        }

        else
        {
            ClearSlot();
        }
    }

    public void UpdateUISlot()
    {
        if (assignedInvSlot != null)
        {
            UpdateUISlot(assignedInvSlot);
        }
    }

    public void OnUISlotClick()
    {
        ParentDisplay?.SlotClicked(this);
    }
}
