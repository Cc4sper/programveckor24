using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //tillägg via kod
    public int ID;
    public string title;
    public string description; 
    public bool canUse = true;

    public bool hasItem = false;

    public virtual void playerPickup()
    {
        hasItem = true;
        //adds to player hotbar 
    }
    public virtual void TryPickup()
    {
        if (hasItem == false)
        {
            playerPickup();
        }
    }
    

    public virtual void TryUseItem()
    {
        if (hasItem && canUse)
        {
            UseItem();
        }
    }
    public virtual void UseItem()
    {
        //effect of item
    }

    public void RemoveItem()
    {
        //remove from hotbar visual
        Destroy(gameObject);
    }
}
