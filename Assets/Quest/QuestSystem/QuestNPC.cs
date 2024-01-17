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
    [SerializeField] private Item requeireItem;
    public Quest currentActiveQuest = null;
    public List <Quest> quests;
    public int activeQuestIndex = 0;
    private Item[] inv;
    [SerializeField] private bool ee = false;


    [SerializeField] Item[] reward;

    void Start()
    {
        inv = FindObjectOfType<HotbarCollect>().itemslots;
        informationNPC.SetActive(false);
        endConversation.SetActive(false);
    }

    void Update()
    {
        if (buttonPressed == true)
        {
            questActive = true;
            AcceptedQuest();
            buttonPressed = false;

        }
        if (questActive == true)
        {
            informationNPC.SetActive(true); 
        }
        /*
        if (AreQuestRequirmentsComplete())
        {
            SubmitItems();
            ReceiveRewardAndCompleteQuest();

        }
        */
        if (Input.GetKeyDown(KeyCode.U))
        {
            ReceiveRewardAndCompleteQuest();
        }

        foreach (Item x in inv)
        {
            if (x.Equals (requeireItem))
            {
                GotAllItems();
            }
        }
    }
    private void AcceptedQuest()
    {
        currentActiveQuest = quests[activeQuestIndex]; // 0 at start
        QuestManager.instance.AddActiveQuest(currentActiveQuest);
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
        QuestManager.instance.MarkQuestComplete(currentActiveQuest);
        
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
        ee = true;
    }
    
   
    public void Button()
    {
        if (answerText.text == "Accept")
        {
            buttonPressed = true;
        }
    }
    


}
