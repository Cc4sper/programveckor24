using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UsableItem : Item
{
    public override void UseItem()
    {
        print("used " +title);
    }

}
