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
    [SerializeField] private GameObject endConversation;
    public string questName;
    public Quest currentActiveQuest = null;
    public List<Quest> quests;
    public int activeQuestIndex = 0;
    public int currentDialog;
    [SerializeField] Item[] reward;

    void Start()
    {
        informationNPC.SetActive(false);
        endConversation.SetActive(false);
        GameObject firstRequiredItem = currentActiveQuest.info.firstRequirmentItem;
    }

    void Update()
    {
        if (answerText.text == "Accept" && buttonPressed == true)
        {
            questActive = true;
            ReceiveRewardAndCompleteQuest();
            buttonPressed = false;
            

        }
        if (questActive == true)
        {
            QuestManager.instance.AddActiveQuest(currentActiveQuest);
            informationNPC.SetActive(true);
        }
        /*
        if (AreQuestRequirmentsComplete())
        {
            SubmitItems();
            ReceiveRewardAndCompleteQuest();

        }
        */


        if ()
        {

        }
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

        
            print("dropping loot");

            for (int i = 0; i < reward.Length; i++)
            {
                float x = Random.Range(-5, 5) / 10f;
                float y = Random.Range(-5, 5) / 10f;
                print(x + " " + y);
                Vector2 dropPoint = transform.position += new Vector3(x, y);
                Instantiate(reward[i], dropPoint, Quaternion.identity);
            }
        }
    
    private void GiveItems()
    {

    }
    
    private void GotAllItems()
    {
        endConversation.SetActive(true);
    }
    
   
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
