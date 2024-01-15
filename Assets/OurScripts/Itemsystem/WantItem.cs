using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantItem : MonoBehaviour
{
    public bool saticified = false;
    bool interactGive;
    [SerializeField] Item wantedItem;
    [SerializeField] int wantedAmount;
    [SerializeField] bool repeat;
    int given;
    Transform player;
    KeyCode playerKey;

    private void Update()
    {
        if (interactGive)
        {
            if (Input.GetKeyDown(playerKey))
            {
                if (player.GetComponent<PlayerHotbarControl>().TryGiveSelected(wantedItem))
                {
                    GotWanted();
 
                }

            }
        }
    }

    void GotWanted()
    {
        given++;
        print("got wanted item "+given+"/"+wantedAmount);
        if (given >= wantedAmount)
        {
            if (saticified == false)
            {
                Saticified();
            }
        }
    }

    public virtual void Saticified()
    {
        saticified = true;
        if (repeat)
        {
            ResetWant();
        }
    }

    void ResetWant()
    {
        given = 0;
        saticified = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && saticified == false)
        {
            if (playerKey == KeyCode.None)
            {
                playerKey = collision.GetComponent<PlayerRespawn>().InteractKey;
                player = collision.transform;
            }
            interactGive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactGive = false;
        }
    }

}
