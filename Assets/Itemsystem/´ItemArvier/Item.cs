using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //tillägg via kod
    public int ID;
    public string title;
    public string description; 
    public bool canUse = true;
    Sprite empty;

    public bool hasItem = false;

    public virtual void playerPickup()
    {
        hasItem = true;
        //adds to player hotbar 
    }
    public virtual void PlayerDrop()
    {
        print("player dropped " + title);
        hasItem = false;
        DeselectItem();
    }
    public virtual void TryPickup()
    {
        if (hasItem == false) //if player dosen't already hold this item it is picked up
        {
            playerPickup();
        }
    }

    public virtual void SelectItem()
    {
        //shows what item does
    }

    public virtual void DeselectItem()
    {
        //reverts selected effect
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

    public virtual void RemoveItem()
    {
        transform.parent.GetComponentInParent<HotbarCollect>().CalledDestroyItem();
        Destroy(gameObject);
    }
}
