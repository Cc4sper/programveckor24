using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarUse : MonoBehaviour
{
    GameObject selectedicon;
    int selectedSlot;

    Item selectedItem;
    public void UseItem(int index)
    {
        selectedItem = GetComponent<HotbarCollect>().itemslots[index];
        if (selectedItem is UsableItem)
        {

        }
    }

    public void SelectItem(int index)
    {
        selectedSlot = index;
        Transform slotObj = GetComponent<HotbarCollect>().slotObj[selectedSlot].transform;
        selectedicon.transform.parent = slotObj;
    }

}
