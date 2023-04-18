using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnMouseItemData : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI itemCount;

    void Awake()
    {
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }
}
