using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "HNS/EnemyDatas", fileName = "Data")]

public class EnemyData : ScriptableObject
{
    public EnemyStats weaponStats;
}

[Serializable]
public class EnemyStats
{
    public int damage;
    public float cooldown;    // Attacking cooldown.

    public int health;
}
