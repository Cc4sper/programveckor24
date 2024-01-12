using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashItem : CooldownItem
{
    public float dashStrength;
    public float dashDuration;
    public bool dashState = false;
    public Transform playerPos;
    public Rigidbody2D rb;
    private Vector2 dir;

    public override void playerPickup()
    {
        base.playerPickup();
        playerPos = transform.parent.parent.GetComponent<HotbarCollect>().playerPos;
        rb = playerPos.GetComponent<Rigidbody2D>();
    }
    public override void UseItem()
    {
        base.UseItem();
        dir = playerPos.up; //dashes at facing direction when item is used
        dashState = true;
    }
    
    public override void Update()
    {
        base.Update();
        if (dashState && dashDuration > cooldown - timer)
        {
            rb.AddForce(dir * dashStrength);
        }
        else
        {
            dashState = false;
        }
    }



}
