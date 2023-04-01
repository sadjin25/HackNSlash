using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable : MonoBehavior
{
    public bool GetDamage(float damage);
}
