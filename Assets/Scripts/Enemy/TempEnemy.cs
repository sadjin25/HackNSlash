using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TempEnemy : EnemyBase
{
    [SerializeField] private EnemyData enemyData;

    private abstract void Attack();

    public bool GetDamage(float damage)
    {
        base.GetDamage(damage);
    }
}


