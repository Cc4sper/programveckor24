using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHotbarControl : MonoBehaviour
{
    [SerializeField] GameObject Hotbar;
    public int selectionSize;
    [SerializeField] KeyCode[] HotbarKeys =
        {KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };
    [SerializeField] KeyCode UseItemKey = KeyCode.Mouse0;



    private void Start()
    {
        Invoke("updateSlotSelection", 1); //wait 
        //updateSlotSelection();
    }
    void Update()
    {
        for (int i = 0; i < selectionSize; i++)
        {
            if (Input.GetKeyDown(HotbarKeys[i]) && selectionSize >= i + 1)
            {
                Hotbar.GetComponent<HotbarUse>().SelectItem(i);
            }
        }
        if (Input.GetKeyDown(UseItemKey))
        {
            print("x");
            Hotbar.GetComponent<HotbarUse>().TryUseItem();
        }
        
    }
    void updateSlotSelection()
    {
        selectionSize = Hotbar.GetComponent<HotbarCollect>().slotAmount;
    }
}
