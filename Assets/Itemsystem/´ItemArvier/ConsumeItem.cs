using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsumeItem : DepleteItem
{
    public int itemHeal = 1;

    public override void UseItem() 
    {
        base.UseItem(); //temp message and deplets
        //get players health + itemHeal
        print("healed "+itemHeal);
    }

}
