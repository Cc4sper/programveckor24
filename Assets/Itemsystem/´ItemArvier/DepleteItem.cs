using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepleteItem : UsableItem
{
    public int amount = 1; //starts of as one
    public int maxAmount = 20; // deafualt 20

    public override void TryPickup()
    {
        if (maxAmount > amount)
        {
            playerPickup();
        }
        else
        {
            print("max amount of item, you squished it in with the rest");
        }
    }
    
    public override void playerPickup()
    {
        if(hasItem)
        {
            print("adding amount");
            amount++; //fixa så att man kan ta fler föremål samtidigt
        }
        else
        {
            hasItem = true;
        }
        transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + amount; //shows amount of item in hotbar
    }
    public override void UseItem()
    {
        base.UseItem(); //temp message
        if (amount > 1)
        {
            amount--;
        }
        else
        {
            base.RemoveItem();
        }
    }

    

}

    



