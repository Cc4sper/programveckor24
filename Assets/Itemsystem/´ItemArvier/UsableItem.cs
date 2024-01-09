using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : Item
{
    public bool canUse = true;

    public virtual void Useitem()
    {
        if (hasItem && canUse)
        {
            //effect of item
        }
    }
}
