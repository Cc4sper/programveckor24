using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UsableItem : Item
{
    //This code made by Noel, is the most "Usable" ;) code there is in our whole game, with no flaws it just makes the whole game lighten up.
    public override void UseItem()
    {
        print("used " +title);
    }

}
