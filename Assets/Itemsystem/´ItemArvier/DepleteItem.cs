using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepleteItem : UsableItem
{
    public int amount = 1; //starts of as one
    public int maxAmount = 20; // deafualt 20

    public override void checkPickup()
    {
        //ifall spelaren har stackable item i hotbar och maxAmount < amount
        //p� den stackable s� g�r ;
        //annars:
        if (maxAmount > amount)
        {
            
            playerPickup();
        }
        else
        {
            print("max amount of item");
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
    }
    public override void UseItem()
    {
        if (amount > 1)
        {
            amount--;
        }
        else
        {
            RemoveItem();
        }
    }

    public void RemoveItem()
    {
        //remove from hotbar and destroy
        Destroy(gameObject);
    }
}

    



