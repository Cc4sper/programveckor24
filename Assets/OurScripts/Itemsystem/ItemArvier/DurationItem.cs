using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationItem : CooldownItem
{
    public bool activeState;
    public float duration;
    public override void UseItem()
    {
        base.UseItem();
        activeState = true;
    }

    public override void Update()
    {
        base.Update();
        if (activeState && timer < cooldown - duration)
        {
            activeState = false;
            RevertState();
        }
    }

    public virtual void RevertState()
    {
        //reverts use item effect
    }

    public override void PlayerDrop()
    {
        RevertState();
        base.PlayerDrop();
    }
}
