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
        if (ID == 8) 
        {
            AudioManager.Instance.PlaySFX("Club");
        }
        else if (ID == 7)
        {
            AudioManager.Instance.PlaySFX("Sword");
        }
        else if (ID == 14)
        {
            AudioManager.Instance.PlaySFX("GroundSlam");
        }
        


    }
}
