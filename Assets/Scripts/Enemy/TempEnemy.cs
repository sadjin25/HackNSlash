using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TempEnemy : EnemyBase
{
    [SerializeField] private EnemyData enemyData;

    protected override void Attack()
    {
    }

    public override bool GetDamage(float damage)
    {
        return base.GetDamage(damage);
    }
}


