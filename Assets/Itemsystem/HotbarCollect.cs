using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HotbarCollect : MonoBehaviour
{
    int emptyIndex = 0;

    bool addingStackable = false;

    public int slotAmount = 0;

    public GameObject slotImage;

    public bool[] filledSlot;
    public Item[] itemslots;
    public GameObject[] slotObj;

    


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
        print("trying to add " + add);
        if (add is DepleteItem)
        {
            print("depletable item");
            emptyIndex = GetSameItemSlot(add);
            
            if (emptyIndex != slotAmount) //if there was a free spot
            {
                itemslots[emptyIndex].TryPickup();
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
        emptyIndex = GetEmptySlot();
        if (emptyIndex == slotAmount)
        {
            print("full off items");
        }
        else
        {
            filledSlot[emptyIndex] = true;
            slotImage = slotObj[emptyIndex].transform.GetChild(0).gameObject;
            slotImage.GetComponent<Image>().color = Color.white;
            slotImage.GetComponent<Image>().sprite = add.GetComponent<SpriteRenderer>().sprite;
            add.transform.parent = slotObj[emptyIndex].transform; //maybe temporary
            itemslots[emptyIndex] = add;
            add.TryPickup();
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

            }
        }
    }

}
