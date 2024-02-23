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

    void Start() //Creates and sets up arrays for storing items in slots 
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

    public void TryAddItem(Item add) //called by player when it picks up item
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
    private void AddItemHotbar(Item add) //Tries to add item to hotbar 
    {
        slotIndex = GetEmptySlot();
        if (slotIndex == slotAmount) //if full hotbar: dropps item of selected slots and then replaces it with the item being picked up
        {
            print("full off items, switching selected"); 
            if (TryDropItem(GetComponent<HotbarUse>().selectedSlot))
            {
                AddItemHotbar(add);
            }
        }
        else //visualy shows item and stores it in hotbar 
        {
            filledSlot[slotIndex] = true;
            slotImage = slotObj[slotIndex].transform.GetChild(1).gameObject; 
            slotImage.GetComponent<Image>().color = Color.white; //Makes item sprite display visual
            slotImage.GetComponent<Image>().sprite = add.GetComponent<SpriteRenderer>().sprite; //adds item sprite into hotbar
            add.transform.parent = slotObj[slotIndex].transform; //puts item as child of corrosponding item slot
            itemslots[slotIndex] = add; //adds item in item array
            add.TryPickup(); //Pickup is called for the Item-object
        }
    }
    //gives index value of the first item slot which shares the inserted items ID, if all slots filled gives index +1 above total slots
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

    int GetEmptySlot() //gives index value of the first empty slot, if all slots filled gives index +1 above total slots
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

    public void CalledDestroyItem() // Item tells hotbar it is removed and that it's need to update it not exsisting
    {
        Invoke("UpdateEmptySlots", 0.1f); 
    }

    private void UpdateEmptySlots() //Checks if any slot is removed, if so it properly removes it visualy 
    {
        for (int i = 0; i < slotAmount; i++) 
        {
            if (itemslots[i] == null) 
            {
                filledSlot[i] = false;
                itemslots[i] = null; //Is not shown as being "missing"
                slotObj[i].transform.GetChild(1).GetComponent<Image>().color = Color.clear;
                slotObj[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    public bool TryDropItem(int slotIndex) //tries to drop item by slot index, and returns true/false if it succeseds 
    {
        if (itemslots[slotIndex] == true)
        {
            itemslots[slotIndex].PlayerDrop(); //the item itself is called as no longer being held 
            itemslots[slotIndex] = null; 
            while (slotObj[slotIndex].transform.childCount > 3) //if dropping a slot with multiple items it only effects the item child
            {
                slotObj[slotIndex].transform.GetChild(3).transform.position = playerPos.position; 
                slotObj[slotIndex].transform.GetChild(3).transform.parent = null; 
            }
            UpdateEmptySlots();
            return true;
        }
        else //nothing happens if it can't drop item
        {
            print("couldn't drop item");
            return false;
        }
    }

    public bool HasWantedSelected(Item wanted) //used by NPC/gates to tell if a player has a specific item returns true/false
    {
        int x = GetComponent<HotbarUse>().selectedSlot; // X is the index of selected slot
        if (filledSlot[x] && itemslots[x].ID == wanted.ID) 
        {
            if (itemslots[x] is DepleteItem) //depletable items are removed one at a time whiles others are completely removed
            {
                itemslots[x].UseItem();
            }
            else
            {
                itemslots[x].RemoveItem();
            }
            return true;
        }
        return false;
    }

    public void DropRandomItem()
    {
        TryDropItem(Random.Range(0,slotAmount));
    }

}
