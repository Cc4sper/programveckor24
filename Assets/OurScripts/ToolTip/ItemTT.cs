using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemTT : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private int sellPrice;


    public string Name { get { return name; } }
    public abstract string ColouredName { get; }
    public abstract string GetTooltipinfoText();
    public int SellPrice { get { return sellPrice; } }


}
