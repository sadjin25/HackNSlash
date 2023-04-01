using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "GameDatas/WeaponStats", fileName = "Data", order = 0)]

public class WeaponData : ScriptableObject
{
    public int rarity;

    public WeaponStats weaponStats;
}

[Serializable]
public class WeaponStats
{
    public float damage;
    public float cooldown;    // Attacking cooldown.
}
