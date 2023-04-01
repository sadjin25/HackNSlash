using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour, IDamagable
{
    protected EnemyData enemyData;

    private abstract void Attack();

    public bool GetDamage(float damage)
    {
        // return true when attack is successful.
        return true;
    }
}


