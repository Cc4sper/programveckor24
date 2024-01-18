using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public ItemTT item;
    [SerializeField] public ToolTipPopUp toolTipPopUp;


    private void OnMouseEnter()
    {
        print("enter");
        toolTipPopUp.DisplayInfo(item);
    }

    private void OnMouseExit()
    {
        print("exit");
        toolTipPopUp.HideInfo();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       // 
        print("enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      //  
        print("exit");
    }
}
