using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QuestRow : MonoBehaviour
{
    public TextMeshProUGUI questName;

    public Button trackingButton;

    public bool isActive;
    public bool isTracking;

    public Quest thisQuest;
    private void Start()
    {
       
        trackingButton.onClick.AddListener(() =>
        {
            if (isActive)
            {
                if (isTracking)
                {
                    isTracking = false;
                    trackingButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Not Tracking";
                    QuestManager.instance.UnTrackQuest(thisQuest);
                }
                else
                {
                    isTracking = true;
                    trackingButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Tracking";
                    QuestManager.instance.TrackQuest(thisQuest);
                }
            }
            

        });
    }

}
