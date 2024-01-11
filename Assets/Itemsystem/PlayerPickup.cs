using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public bool InRangePickup = false;
    public KeyCode pickupKey = KeyCode.E;
    public HotbarCollect bar;
    public Item colItem;
    public GameObject colObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //add tag to item
        colObj = collision.gameObject;
        print("triggered");
        InRangePickup = true;
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InRangePickup = false;
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(pickupKey) && InRangePickup)
        {
            colItem = colObj.GetComponent<Item>();
            colObj.transform.position = new Vector2(0, 100); //temporary to make item disapear without removing it
            print("picking up " + colItem.title);
            bar.AddItem(colItem);
            
        }
    }
}
