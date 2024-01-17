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
    public KeyCode questTab = KeyCode.Tab;
    private void Start()
    {
        questMenu.SetActive(false);
        isQuestMenuOpen = false;
    }
   
    private void Awake()
    {
        if (instance != null && !this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public List<Quest> allActiveQuests;
    public List<Quest> allCompletedQuests;

    [Header("QuestMenu")]
    public GameObject questMenu;
    public bool isQuestMenuOpen;

    public GameObject activeQuestPrefab;

    public Transform questMenuContent;

    [Header("QuestTracker")]
    public GameObject questTrackerContent;

    private void Update()
    {
        if (Input.GetKeyDown(questTab) && isQuestMenuOpen == false)
        {
            questMenu.SetActive(true);
            isQuestMenuOpen = true;
        }
        else if (Input.GetKeyDown(questTab) && isQuestMenuOpen == true)
        {
            questMenu.SetActive(false);
            isQuestMenuOpen = false;
        }
    }
    public void AddActiveQuest(Quest quest)
    {
        allActiveQuests.Add(quest);
        RefreshQuestList();
    }
    public void MarkQuestComplete(Quest quest)
    {
        allActiveQuests.Remove(quest);
        RefreshQuestList();
    }
    
    public void RefreshQuestList()
    {
        foreach (Transform child in questMenuContent.transform)
        {
            Destroy(child.gameObject);
        }
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
