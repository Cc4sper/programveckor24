using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Items/Consumable")]
public class Consumable : ItemTT
{
    [SerializeField] private Rarity rarity;
    [SerializeField] private string UseText = "Use: Something";
    [SerializeField] private string flavorText = "";


    public Rarity Rarity { get { return rarity; } }
    
    public override string ColouredName
    {
        get
        {
            string hexColour = ColorUtility.ToHtmlStringRGB(rarity.TextColor);
            return $"<color=#{hexColour}>{Name}</color>";
        }
    }
    public override string GetTooltipinfoText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(Rarity.Name).AppendLine();
        builder.Append("<color=green>").Append(UseText).Append("</color>").AppendLine();
        //builder.Append("Sell Price: ").Append(SellPrice).Append(" Ryal"); sellprice men vi hade inte tid att få det att funka.
        builder.Append("<color=yellow>").Append(flavorText).Append("</color>").AppendLine();
        return builder.ToString();
            
    }
}
