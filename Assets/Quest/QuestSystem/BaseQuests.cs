using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseQuests : MonoBehaviour
{
    bool IsActive;
    public GameObject QuestBox;
    void Start()
    {
     QuestBox.SetActive(false);

    }
    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            QuestBox.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                QuestBox.SetActive(true);
            }
        }
    }
}
