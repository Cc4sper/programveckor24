using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : CooldownItem
{
    public int baseDamage;
   
    public float reach;
    public GameObject Attackprefab;
    public Transform playerPos;
    public GameObject newAttack;
    //public GameObject newAttack;

    public override void playerPickup()
    {
        base.playerPickup(); //whiles in inventory playerPos can be 
        playerPos = transform.parent.parent.GetComponent<HotbarCollect>().playerPos;
    }
    public override void UseItem()
    {
        newAttack = Instantiate(Attackprefab, playerPos.position + (playerPos.up * reach), playerPos.rotation);
        newAttack.GetComponent<GenericAttack>().damage = baseDamage;
        base.UseItem(); //holds cooldown effect

    }
}
