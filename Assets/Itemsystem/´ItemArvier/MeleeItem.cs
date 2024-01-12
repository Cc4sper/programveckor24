using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeItem : CooldownItem
{
    public int baseDamage;
    public float moveSpeed;
    public float reach;
    public GameObject Attackprefab;
    public Transform playerPos;
    
    public override void playerPickup()
    {
        base.playerPickup(); //whiles in inventory playerPos can be 
        playerPos = transform.parent.parent.GetComponent<HotbarCollect>().playerPos;
    }
    public override void UseItem()
    {
        GameObject newStrike = Instantiate(Attackprefab, playerPos.position, playerPos.rotation);

        newStrike.transform.position += (playerPos.up * reach);
        newStrike.GetComponent<Rigidbody2D>().AddForce(playerPos.up * moveSpeed, ForceMode2D.Force);
        newStrike.GetComponent<GenericAttack>().damage = baseDamage;
        base.UseItem(); //holds cooldown effect

    }
}
