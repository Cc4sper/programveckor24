using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseQuests : MonoBehaviour
{
    bool IsActive;
    public void OnTriggerEnter2D(Collision2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
           
        }
    }
}
