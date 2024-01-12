using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EduipItem : Item
{
    public override void playerPickup()
    {
        base.playerPickup();
        //constant effect
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

    public virtual void LoseEffect()
    {
        //lose same effect
    }
}
