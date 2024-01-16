using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;
using UnityEngine.UI;

public class QuestNPC : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] bool buttonPressed = false;
    bool questActive = false;
    [SerializeField] private GameObject informationNPC;
    public string questName;
    public Quest currentActiveQuest = null;
    public List<Quest> quests;
    public int activeQuestIndex = 0;
    public int currentDialog;
    public Item colItem;
    public GameObject colObj;
    public HotbarCollect bar;
    void Start()
    {
        informationNPC.SetActive(false);

    }

    void Update()
    {
        if (answerText.text == "Accept" && buttonPressed == true)
        {
            questActive = true;
            ReceiveRewardAndCompleteQuest();
            buttonPressed = false;
            Instantiate(colObj);

        }
        if (questActive == true)
        {
            // QuestManager.instance.AddActiveQuest(currentActiveQuest);
            informationNPC.SetActive(true);
        }
        /*
        if (AreQuestRequirmentsComplete())
        {
            SubmitItems();
            ReceiveRewardAndCompleteQuest();

        }
        */

    }
    private void AcceptedQuest()
    {
        currentActiveQuest.accepted = true;

        if (currentActiveQuest.hasNoRequirements)
        {
            ReceiveRewardAndCompleteQuest(); 
        }
        else
        {

        }
    }

    private void ReceiveRewardAndCompleteQuest()
    {
        colItem = colObj.GetComponent<Item>();
        colObj.transform.position = new Vector2(0, 500); //temporary to make item disapear without removing it
        print("Got " + colItem.title + " from NPC");
        bar.TryAddItem(colItem);      
    }
    
    /*
    private bool AreQuestRequirmentsComplete()
    {
        print("Checking Requiremnts");
        // First Item Requirment
        
        string firstRequiredItem = currentActiveQuest.info.firstRequirmentItem;
        int firstRequiredAmount = currentActiveQuest.info.firstRequirementAmount;

        var firstItemCounter = 0;

        foreach (string item in HotbarCollect.instance)
        {
            if (item == firstRequiredItem)
            {
                firstItemCounter++;
            }
        }

        // Second Item Requirment -- If we dont have a second item, just set it to 0

        string secondRequiredItem = currentActiveQuest.info.secondRequirmentItem;
        int secondRequiredAmount = currentActiveQuest.info.secondRequirementAmount;

        var secondItemCounter = 0;

        foreach (string item in InventorySystem.Instance.itemList)
        {
            if (item == secondRequiredItem)
            {
                secondItemCounter++;
            }
        }

        if (firstItemCounter >= firstRequiredAmount && secondItemCounter >= secondRequiredAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   */
    public void Button()
    {
        if (answerText.text == "Accept")
        {
            buttonPressed = true;
        }
    }
    /*

    /*
    private void AcceptedQuest()
    {
        currentActiveQuest.accepted = true;
        currentActiveQuest.declined = false;


    }
    */
}
