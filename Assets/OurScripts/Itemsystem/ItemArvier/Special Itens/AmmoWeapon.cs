using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoWeapon : RangedItem
{
    public int maxAmmo;
    public int ammo;
    public override void UseItem()
    {
        ammo--;
        base.UseItem();
        if (ammo > 0)
        {
            timer = 0;
        }
       
    }
    public override void Update()
    {
        base.Update();
        if (canUse == true && ammo == 0)
        {
            ammo = maxAmmo;
        }
    }
}
