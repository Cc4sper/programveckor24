using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeItem : WeaponItem
{
    public float meleeForce;
    public override void UseItem()
    {
        base.UseItem(); //creates a melee strike and adds melee force 
        newAttack.GetComponent<Rigidbody2D>().AddForce(playerPos.up * meleeForce, ForceMode2D.Force);

    }
}
