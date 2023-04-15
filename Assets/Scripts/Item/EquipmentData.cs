using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemData : ScriptableObject
{
    public int ID;
    public string itemName;
    public string description;
    public Sprite sprite;
    public int rarity;
    public ItemType itemType;
    public int maxStackSize;
}
