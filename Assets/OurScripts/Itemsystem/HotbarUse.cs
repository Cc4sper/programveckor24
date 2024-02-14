using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HotbarUse : MonoBehaviour
{
    
    public int selectedSlot = 0;
    Item selectedItem;
    public void TryUseItem()
    {
        if (HasSelectedItem())
        {
            selectedItem = GetComponent<HotbarCollect>().itemslots[selectedSlot];
            print("Tried using" + selectedItem.title);
            if (selectedItem is UsableItem)
            {
                UseItem();
            }
        }
        else
        {
            print("no item to use");
        }
    }

    private void UseItem()
    {
        selectedItem.TryUseItem();
    }
    
    public void DropItem()
    {
        GetComponent<HotbarCollect>().TryDropItem(selectedSlot);
    }

    public void SelectItem(int index)
    {
        print("selected slot "+index);
        GetComponent<HotbarCollect>().slotObj[selectedSlot].transform.GetChild(0).GetComponent<Image>().color = new Color(0.9f, 0.9f, 0.9f, 0.5f); //resets color of last selected
        if (GetComponent<HotbarCollect>().filledSlot[selectedSlot] == true)
        {
            GetComponent<HotbarCollect>().itemslots[selectedSlot].DeselectItem();
        }
        
        selectedSlot = index;
        GetComponent<HotbarCollect>().slotObj[selectedSlot].transform.GetChild(0).GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f,0.5f);
        if (GetComponent<HotbarCollect>().filledSlot[selectedSlot] == true)
        {
            GetComponent<HotbarCollect>().itemslots[selectedSlot].SelectItem();
        }
    }
    
    public bool HasSelectedItem()
    {
        if (GetComponent<HotbarCollect>().itemslots[selectedSlot] != null)
        {
            return true;
        }
        return false;
    }
}
