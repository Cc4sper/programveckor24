using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : EduipItem
{
    public int Armor; //extra hp onto player
    public override void UseItem()
    {
        base.UseItem();

    }

    public override void PlayerDrop()
    {
        LoseEffect();
        base.PlayerDrop();
    }
    public override void RemoveItem()
    {
        LoseEffect();
        base.RemoveItem();
    }

    public void LoseEffect()
    {

    }
}
