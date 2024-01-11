using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HotbarCollect : MonoBehaviour
{
    int slotIndex = 0;

    public int slotAmount = 0;

    private GameObject slotImage;

    public bool[] filledSlot;
    public Item[] itemslots;
    public GameObject[] slotObj;

    public Item LastCollectItem;

    public Transform playerPos;


    void Start()
    {
        slotAmount = gameObject.transform.childCount;
        filledSlot = new bool[slotAmount];
        slotObj = new GameObject[slotAmount];
        itemslots = new Item[slotAmount];

        for (int i = 0; i < filledSlot.Length; i++)
        {
            slotObj[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item add) //called by player when it picks up item
    {
        print("trying to add " + add.title);
        LastCollectItem = add; //saved for later use 
        if (add is DepleteItem)
        {
            print("depletable item");
            slotIndex = GetSameItemSlot(add);
            
            if (slotIndex != slotAmount) //if there was a free spot
            {
                add.transform.parent = slotObj[slotIndex].transform;
                itemslots[slotIndex].TryPickup();
                print("stacked item");
            }
            else
            {
                print("there was no same object");
                AddItemHotbar(add);
            }
        }
        else
        {
            print("other item");
            AddItemHotbar(add);
        }
    }
    private void AddItemHotbar(Item add)
    {
        slotIndex = GetEmptySlot();
        if (slotIndex == slotAmount)
        {
            print("full off items, switching selected");
        }
        else
        {
            filledSlot[slotIndex] = true;
            slotImage = slotObj[slotIndex].transform.GetChild(0).gameObject; 
            slotImage.GetComponent<Image>().color = Color.white; //Makes item sprite display visual
            slotImage.GetComponent<Image>().sprite = add.GetComponent<SpriteRenderer>().sprite; //adds item sprite into hotbar
            add.transform.parent = slotObj[slotIndex].transform; //puts item as child of corrosponding item slot
            itemslots[slotIndex] = add; //adds item in item array
            add.TryPickup(); //Pickup is called for the Item-object
        }
    }

    int GetSameItemSlot(Item itm)
    {
        int result = slotAmount;
        for (int i = 0; i < filledSlot.Length; i++)
        {
            if (itemslots[i] is DepleteItem && itm.ID == itemslots[i].ID)
            {
                result = i;
                break;
            }
        }
        return result;
    }

    int GetEmptySlot()
    {
        int result = slotAmount;
        for (int i = 0; i < filledSlot.Length; i++)
        {
            if (filledSlot[i] == false)
            {
                result = i;
                break;
            }
        }
        return result;
    }

    public void CalledDestroyItem() //slots with no items are marked as empty, is called from item when being destroyed
    {
        Invoke("UpdateFilledSlots", 0.1f); 
    }

    private void UpdateFilledSlots()
    {
        for (int i = 0; i < slotAmount - 1; i++)
        {
            if (itemslots[i] == null)
            {
                filledSlot[i] = false;
                itemslots[i] = null; //if it was missing it's now not exsisting
                slotObj[i].transform.GetChild(0).GetComponent<Image>().color = Color.clear;
                slotObj[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void TryDropItem(int slotIndex)
    {
        if (filledSlot[slotIndex] == true)//if it exsist
        {
            //itemslots[slotIndex].transform.position = playerPos.position; //teleports to player, as if it was dropped off by player
            //itemslots[slotIndex].transform.parent = null; //detaches item as child of hotbar slot
            
            while (slotObj[slotIndex].transform.childCount > 2)
            {
                slotObj[slotIndex].transform.GetChild(2).transform.position = playerPos.position; //teleports all items in dropped slot to player
                slotObj[slotIndex].transform.GetChild(2).transform.parent = null; //detaches all item as child of hotbar slot
            }

            itemslots[slotIndex].PlayerDrop();
            itemslots[slotIndex] = null;
            UpdateFilledSlots();
        }
        else
        {
            print("couldn't drop item");
        }
        
    }

}
