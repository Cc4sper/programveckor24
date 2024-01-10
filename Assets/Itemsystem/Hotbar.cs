using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    int emptyIndex = 0;

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
            emptyIndex = GetSameItemSlot(add);
            print("depletable item");
            if (emptyIndex == slotAmount)
            {
                print("there was no same object");
                emptyIndex = GetEmptySlot();
            }
            else
            {
                print("stacked item");
                add.checkPickup();
            }
        }
        else
        {
            print("other item");
            emptyIndex = GetEmptySlot();
        }
        
        
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
            //add.transform.parent = slotObj[GetEmptySlot()].transform; //maybe temporary

            itemslots[emptyIndex] = add;

            add.checkPickup();
        }
        

    }

    int GetSameItemSlot(Item itm)
    {
        int result = slotAmount;
        for (int i = 0; i < filledSlot.Length; i++)
        {
            if (itemslots[i] is DepleteItem)
            {
                if (itm.ID == itemslots[i].ID)
                {
                    result = i;
                    break;
                }
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
}
