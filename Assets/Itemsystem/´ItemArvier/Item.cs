using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //tillägg via kod
    public string name;
    public string description; 

    public bool hasItem = false;

    public virtual void playerPickup()
    {
        //adds to player hotbar 
    }
    public virtual void checkPickup()
    {
        if (hasItem == false)
        {
            playerPickup();
        }
    }
}
