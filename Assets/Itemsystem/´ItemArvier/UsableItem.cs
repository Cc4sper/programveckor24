using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : Item
{
    public override void UseItem()
    {
        print("used " +name);
    }

}
