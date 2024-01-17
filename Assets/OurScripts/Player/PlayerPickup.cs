using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public float CooldownScalar = 1;
    public int strength = 0;
    public bool InRangePickup = false;
    public KeyCode pickupKey = KeyCode.E;

    public HotbarCollect bar;
    public Item colItem;
    public GameObject colObj;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            colObj = collision.gameObject;
            print("triggered pickup");
            InRangePickup = true;
        }
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
            colObj.transform.position = new Vector2(0, 500); //temporary to make item disapear without removing it
            print("picking up " + colItem.title);
            bar.TryAddItem(colItem);
            
        }
    }
}
