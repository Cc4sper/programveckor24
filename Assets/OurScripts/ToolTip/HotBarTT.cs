using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotBarTT : ToolTipPopUp, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField] public ItemTT item;
    [SerializeField] public ToolTipPopUp toolTipPopUp;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        DisplayInfo(item);
    }

    

     void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        HideInfo();
    }

   

  /*  private void OnMouseEnter()
    {
        print("hotbarentr");
        item = transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<ItemButton>();
        item.toolTipPopUp.DisplayInfo(item.item);
    }

    private void OnMouseExit()
    {
        print("hotbarexit");
        item.toolTipPopUp.HideInfo();
    }*/
}
