using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public int size;
    public bool[] filledSlot;
    public Item[] itemslots;
    
    void Start()
    {
        filledSlot = new bool[size];
        itemslots = new Item[size];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item add) //called by player when it picks up item
    {
        itemslots[GetEmptySlot()] = add;
    }

    int GetEmptySlot()
    {
        int result = 0;
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
