using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownItem : UsableItem
{
    public float cooldown = 1; //cooldown in seconds
    public float timer = 0; 

    public override void UseItem()
    {
        base.UseItem(); //temp message
        canUse = false;
        cooldown = timer;
    }


    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (canUse == false)
        {
            canUse = true;
        }
    }
}
