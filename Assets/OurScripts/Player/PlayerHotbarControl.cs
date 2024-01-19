using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHotbarControl : MonoBehaviour
{
    public GameObject Hotbar;
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
    [SerializeField] KeyCode DropItemKey = KeyCode.Q;



    private void Start()
    {
        Invoke("updateSlotSelection", 1); //waits for load
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
            Hotbar.GetComponent<HotbarUse>().TryUseItem();
        }
        if (Input.GetKeyDown(DropItemKey))
        {
            Hotbar.GetComponent<HotbarUse>().DropItem();
        }

    }
    void updateSlotSelection()
    {
        selectionSize = Hotbar.GetComponent<HotbarCollect>().slotAmount;
    }
    public bool TryGiveSelected(Item wanted)
    {
        if (Hotbar.GetComponent<HotbarCollect>().HasWantedSelected(wanted))
        {
            return true;
        }
        return false;
        
    }
}
