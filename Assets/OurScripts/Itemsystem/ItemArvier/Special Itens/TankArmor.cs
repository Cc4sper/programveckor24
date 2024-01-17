using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankArmor : ArmorItem
{
    public override void playerPickup()
    {
        base.playerPickup();
        player.GetComponent<PlayerMove>().moveSpeed -= 1;
    }
    public override void LoseEffect()
    {
        base.LoseEffect();
        player.GetComponent<PlayerMove>().moveSpeed += 1;
    }
}
