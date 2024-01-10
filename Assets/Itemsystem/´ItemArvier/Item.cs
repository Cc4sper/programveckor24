using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //till�gg via kod
    public string title;
    public string description; 

    public bool hasItem = false;

    public virtual void playerPickup()
    {
        hasItem = true;
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
