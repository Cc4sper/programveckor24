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
    public Transform questTrackerContent;
    public GameObject trackerRowPrefab;
    public List<Quest> allTrackedQuest;

    public void TrackQuest(Quest quest)
    {
        allTrackedQuest.Add(quest);
        RefreshTrackerList();
    }
    public void UnTrackQuest(Quest quest)
    {
        allTrackedQuest.Remove(quest);
        RefreshTrackerList();

    }
    
    private void RefreshTrackerList()
    {
        foreach (Transform child in questTrackerContent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Quest trackedQuest in allTrackedQuest)
        {
            GameObject trackerPrefab = Instantiate(trackerRowPrefab);
            trackerPrefab.transform.SetParent(questTrackerContent);
            trackerPrefab.transform.localScale = Vector2.one;
            QuestTracked tRow = trackerPrefab.GetComponent<QuestTracked>();            
            tRow.questName.text = trackedQuest.questName;
            tRow.requirements.text = trackedQuest.questRequirements;
            tRow.description.text = trackedQuest.questDescription;

            


        }
    }
    
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
        TrackQuest(quest);
        RefreshQuestList();
    }
    public void MarkQuestComplete(Quest quest)
    {
        allActiveQuests.Remove(quest);
        UnTrackQuest(quest);
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

            qRow.thisQuest = activeQuest;

            qRow.questName.text = activeQuest.questName;


            qRow.isActive = true;
            qRow.isTracking = true;

            

            
        }
    }
   
}
