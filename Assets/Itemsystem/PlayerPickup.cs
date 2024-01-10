using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public bool InRangePickup = false;
    public KeyCode pickupKey = KeyCode.E;
    public Hotbar bar;
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("triggered");
        //add tag to item

        if (Input.GetKeyDown(pickupKey)) 
        {
            bar.AddItem(collision.GetComponent<Item>());
        }
    }
}
