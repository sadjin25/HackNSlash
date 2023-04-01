using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    private Weapons weapon;

    public WeaponHandler(Weapons _weapon)
    {
        weapon = _weapon;
    }

    public void Attack()
    {
        Debug.Log("Attack is called by weaponhandler");
    }
}
