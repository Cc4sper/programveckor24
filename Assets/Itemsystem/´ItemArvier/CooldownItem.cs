using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownItem : UsableItem
{
    public float cooldown = 1; //cooldown in seconds
    public float timer = 0;

    public Transform playerPos;

    public Transform visual;
    public SpriteRenderer visualSprite;
    public Vector3 visualPos;


    public virtual void Start()
    {
        visual = transform.GetChild(0);
        visualSprite = visual.GetComponent<SpriteRenderer>();
        visualPos = visual.transform.position - transform.position;
    }
    public virtual void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (canUse == false)
        {
            canUse = true;
        }
        if (canUse == false)
        {
            visualSprite.color = new Color(1, 1, 1, 0.5f - timer / cooldown * 0.5f);
        }
        else
        {
            visualSprite.color = Color.white;
        }

    }
    public override void playerPickup()
    {
        base.playerPickup();
        playerPos = transform.parent.parent.GetComponent<HotbarCollect>().playerPos; //gets player transform 
    }

    public override void SelectItem()
    {
        visual.parent = playerPos;
        visual.transform.position = playerPos.position; //copies players pos and rot and moves according to how it is pre-set in item
        visual.rotation = playerPos.rotation;
        visual.transform.localPosition += visualPos; 

        visual.gameObject.SetActive(true);
    }
    public override void DeselectItem()
    {
        visual.gameObject.SetActive(false);
        visual.parent = transform;
    }
    public override void UseItem()
    {
        base.UseItem(); //temp message
        canUse = false;
        timer = cooldown;
    }


    
}
