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
        if (GetComponent<HotbarCollect>().itemslots[selectedSlot] != null)
        {
            selectedItem = GetComponent<HotbarCollect>().itemslots[selectedSlot];
            print("Tried using" + selectedItem.name);
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
        GetComponent<HotbarCollect>().slotObj[selectedSlot].GetComponent<Image>().color = Color.gray; //resets color of last selected

        selectedSlot = index;
        GetComponent<HotbarCollect>().slotObj[selectedSlot].GetComponent<Image>().color = new Color(0.3f,0.3f,0.3f,1);
    }
}
