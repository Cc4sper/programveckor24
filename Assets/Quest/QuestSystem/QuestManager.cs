using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance { get; set; }

    private void Awake()
    {
        
    }

    public List<Quest> allActiveQuests;

    [Header("QuestMenu")]
    public GameObject questMenu;
    public bool isQuestMenuOpen;

    public GameObject activeQuestPrefab;

    public Transform questMenuContent;

    [Header("QuestTracker")]
    public GameObject questTrackerContent;

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject questPrefab = Instantiate(activeQuestPrefab);
            questPrefab.transform.SetParent(questMenuContent);
            questPrefab.transform.localScale = Vector2.one;

        }

    }
    */
    public void AddActiveQuest(Quest quest)
    {
        allActiveQuests.Add(quest);
        RefreshQuestList();
    }
    
    public void RefreshQuestList()
    {
        foreach (Quest activeQuest in allActiveQuests)
        {
            GameObject questPrefab = Instantiate(activeQuestPrefab);
            questPrefab.transform.SetParent(questMenuContent);
            questPrefab.transform.localScale = Vector2.one;
            QuestRow qRow = questPrefab.GetComponent<QuestRow>();
            qRow.questName.text = activeQuest.questName;

            qRow.isActive = true;
            qRow.isTracking = true;

            
        }
    }
   
}
