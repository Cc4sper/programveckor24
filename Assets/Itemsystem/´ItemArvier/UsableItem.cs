using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : Item
{
    public bool canUse = true;

    public virtual void CheckUseItem()
    {
        if (hasItem && canUse)
        {
            UseItem();
        }
    }

    public virtual void UseItem()
    {
        //effect of item
    }
}
