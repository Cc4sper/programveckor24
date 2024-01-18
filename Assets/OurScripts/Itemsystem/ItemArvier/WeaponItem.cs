using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : CooldownItem
{
    public int baseDamage;
   
    public float reach;
    public float weight;
    public GameObject Attackprefab;
    public GameObject newAttack;
    public bool slowedPlayer;
    //public GameObject newAttack;

    public override void playerPickup()
    {
        base.playerPickup(); //whiles in inventory playerPos can be 
        playerPos = transform.parent.parent.GetComponent<HotbarCollect>().playerPos;
    }
    public override void UseItem()
    {
        newAttack = Instantiate(Attackprefab, playerPos.position + (playerPos.up * reach), playerPos.rotation);
        newAttack.GetComponent<GenericAttack>().damage = baseDamage + playerPos.GetComponent<PlayerPickup>().strength;
        playerPos.GetComponent<PlayerMove>().Slowed(true);
        slowedPlayer = true;
        base.UseItem(); //holds cooldown effect

    }
    public override void Update()
    {
        base.Update();
        if (timer < cooldown - weight && slowedPlayer == true)
        {
            slowedPlayer = false;
            playerPos.GetComponent<PlayerMove>().Slowed(false);
        }
    }
}
