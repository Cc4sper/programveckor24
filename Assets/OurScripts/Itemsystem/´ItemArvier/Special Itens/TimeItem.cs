using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItem : DurationItem
{
    
    public override void UseItem()
    {
        base.UseItem();
        Time.timeScale = 0.25f;
        playerPos.GetComponent<PlayerMove>().moveSpeed *= 4;
        playerPos.GetComponent<PlayerPickup>().CooldownScalar /= 8f;
    }

    public override void RevertState()
    {
        Time.timeScale = 1;
        playerPos.GetComponent<PlayerMove>().moveSpeed /= 4f;
        playerPos.GetComponent<PlayerPickup>().CooldownScalar *= 8f;
    }
}
