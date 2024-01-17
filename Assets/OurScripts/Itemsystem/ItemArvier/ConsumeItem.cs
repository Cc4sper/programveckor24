using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsumeItem : DepleteItem
{
    public int itemHeal = 1;

    public override void UseItem() 
    {
        if(ID==1)
        base.UseItem(); //temp message and deplets
        transform.parent.GetComponentInParent<HotbarCollect>().playerPos.GetComponent<PlayerHealth>().HealHealth(itemHeal);
        AudioManager.Instance.PlaySFX("Apple");
        if (ID == 2)
            base.UseItem(); //temp message and deplets
        transform.parent.GetComponentInParent<HotbarCollect>().playerPos.GetComponent<PlayerHealth>().HealHealth(itemHeal);
        AudioManager.Instance.PlaySFX("Water");
        if (ID == 3)
            base.UseItem(); //temp message and deplets
        transform.parent.GetComponentInParent<HotbarCollect>().playerPos.GetComponent<PlayerHealth>().HealHealth(itemHeal);
        AudioManager.Instance.PlaySFX("Biscuit");
    }


}
