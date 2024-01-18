using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotBarTT : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    ItemButton item;
    
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        print("enter");
        item = transform.GetChild(2).GetComponent<ItemButton>();
        item.toolTipPopUp.DisplayInfo(item.item);
    }

    

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        print("exit");
        item.toolTipPopUp.HideInfo();
    }

   

    private void OnMouseEnter()
    {
        
    }

    private void OnMouseExit()
    {
        
    }
}
