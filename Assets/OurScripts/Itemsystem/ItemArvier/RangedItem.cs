using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedItem : WeaponItem
{
    public float ProjectileSpeed;
    public override void UseItem()
    {
        if (ID==10)
        base.UseItem(); //creates a melee strike and adds melee force 
        newAttack.GetComponent<Rigidbody2D>().velocity = playerPos.up * ProjectileSpeed;
        AudioManager.Instance.PlaySFX("SandGun");
        if(ID==11)
        base.UseItem(); //creates a melee strike and adds melee force 
        newAttack.GetComponent<Rigidbody2D>().velocity = playerPos.up * ProjectileSpeed;
        AudioManager.Instance.PlaySFX("MerfGun");
    }
}
