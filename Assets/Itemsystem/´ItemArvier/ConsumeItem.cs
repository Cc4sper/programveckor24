using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeItem : DepleteItem
{
    public int itemHeal = 1;

    public override void UseItem()
    {
        //get players health + itemHeal
        print("healed "+itemHeal);
    }

}
