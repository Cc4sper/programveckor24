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
        //ifall spelaren har stackable item i hotbar och maxAmount < amount
        //på den stackable så går ;
        //annars:
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
            amount++;
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

    public override void RemoveItem()
    {
        base.RemoveItem();
        transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
    }


}

    



