using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : EduipItem
{
    public Transform player;
    public int Armor; //extra hp onto player
    public override void playerPickup()
    {
        base.playerPickup();
        player = transform.parent.parent.GetComponent<HotbarCollect>().playerPos;
        player.GetComponent<PlayerHealth>().armor += Armor;
    }

    public override void LoseEffect()
    {
        player.GetComponent<PlayerHealth>().armor -= Armor;
    }
}
