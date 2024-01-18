using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongArmor : ArmorItem
{
    public int strengthIncrease;
    public override void playerPickup()
    {
        base.playerPickup();
        player.GetComponent<PlayerPickup>().strength += strengthIncrease;
    }

    public override void LoseEffect()
    {
        base.LoseEffect();
        player.GetComponent<PlayerPickup>().strength -= strengthIncrease;
    }
}
