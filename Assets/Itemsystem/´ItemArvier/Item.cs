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
        if (hasItem == false)
        {
            hasItem = true;
        }
    }
}
