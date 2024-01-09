using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepleteItem : UsableItem
{
    public int amount;

    public override void playerPickup()
    {
        amount++;
    }

    
}
