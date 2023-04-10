using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "HNS/WeaponDatas", fileName = "Data")]

public class WeaponData : ScriptableObject
{
    public int rarity;
    public ItemType itemType;
    public WeaponType weaponType;
    public WeaponStats weaponStats;
}

[Serializable]
public class WeaponStats
{
    public int damage;
    public float cooldown;    // Attacking cooldown.
}


public enum WeaponType
{
    Sword,
    Bow
}