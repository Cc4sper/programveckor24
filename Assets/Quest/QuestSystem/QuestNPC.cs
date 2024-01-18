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
    [SerializeField] private GameObject firstConversation;
    [SerializeField] private GameObject talkNPC;
    [SerializeField] private GameObject endConversation;
    [SerializeField] private Item requeireItem;
    [SerializeField] private Quest currentActiveQuest = null;
    [SerializeField] bool haveReward;
    [SerializeField] bool talkQuest;
    [SerializeField] bool gatherQuest;
    [SerializeField] string talkquestBye;
    private Quest currentTrackedQuest = null;
    public Button activateButton;    //public List <Quest> quests;
    public int activeQuestIndex = 0;
    public int trackedQuestIndex = 0;
    private Item[] inv;
    bool playerInRange = false;

    [SerializeField] private bool ee = false;


    [SerializeField] Item[] reward;

    void Start()
    {
        if (gatherQuest)
        {
            endConversation.SetActive(false);
        }
        
        activateButton.onClick.AddListener(() =>
        {
            if (answerText.text == "Accept" || answerText.text == "Bye" && playerInRange)
            {
                questActive = true;
                AcceptedQuest();

            }
            if (talkQuest && answerText.text == talkquestBye)
            {
                ReceiveRewardAndCompleteQuest();    
            }
            if (gatherQuest && answerText.text == talkquestBye)
            {
                ReceiveRewardAndCompleteQuest();
            }

        });
        inv = GetComponent<HotbarCollect>().itemslots;
        talkNPC.SetActive(false);
        
    }
    
    void Update()
    {

       
        if (questActive == true)
        {
            talkNPC.SetActive(true); 
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
            CompletedObjective();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    private void AcceptedQuest()
    {
        firstConversation.SetActive(false);
        //currentActiveQuest = quests[activeQuestIndex]; // 0 at start
        //currentTrackedQuest = quests[activeQuestIndex]; // 0 at start
        QuestManager.instance.AddActiveQuest(currentActiveQuest);
        currentActiveQuest.accepted = true;

        if (currentActiveQuest.hasNoRequirements)
        {
            ReceiveRewardAndCompleteQuest(); 
        }
        else
        {
            if (talkQuest)
            {
                talkNPC.SetActive(true);
            }
        }
    }

    private void ReceiveRewardAndCompleteQuest()
    {
        if (haveReward)
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
        QuestManager.instance.MarkQuestComplete(currentActiveQuest);
        
            
    }
    
    private void GiveItems()
    {

    }
    
    private void CompletedObjective()
    {
        endConversation.SetActive(true);
        ee = true;
    }
    
   
    
    


}
