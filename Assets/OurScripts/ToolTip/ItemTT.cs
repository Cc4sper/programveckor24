using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemTT : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private int sellPrice;


    public string Name { get { return name; } } // Namn f�r item
    public abstract string ColouredName { get; } // tar f�rgen fr�n rarityn som du anget.
    public abstract string GetTooltipinfoText(); // informationen du har get itemet.
    public int SellPrice { get { return sellPrice; } } // Skulle vara sell price men det hade vi inte tid med.


}
