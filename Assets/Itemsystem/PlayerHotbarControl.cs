using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHotbarControl : MonoBehaviour
{
    [SerializeField] GameObject Hotbar;
    int selectionSize;
    KeyCode[] HotbarKeys =
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

    private void Start()
    {
        updateSlotSelection();
    }
    void Update()
    {
        if (Input.GetKeyDown(HotbarKeys[0]) && selectionSize >= 0+1)
        {
            Hotbar.GetComponent<HotbarUse>().SelectItem(0);
        }
    }
    void updateSlotSelection()
    {
        selectionSize = Hotbar.GetComponent<HotbarCollect>().slotAmount;
    }
}
