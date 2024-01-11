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

    public virtual void RemoveItem()
    {
        transform.parent.GetChild(0).GetComponent<Image>().color = Color.clear; //remove from hotbar visual
        transform.parent.GetComponentInParent<HotbarCollect>().CalledDestroyItem();
        Destroy(gameObject);
        
    }
}
