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
    [SerializeField] private GameObject talkNPC;
    [SerializeField] private GameObject endConversation;
    [SerializeField] private Item requeireItem;
    [SerializeField] private Quest currentActiveQuest = null;
    [SerializeField] bool haveReward;
    [SerializeField] bool talkQuest;
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
        activateButton.onClick.AddListener(() =>
        {
            if (answerText.text == "Accept" || answerText.text == "Bye" && playerInRange)
            {
                questActive = true;
                AcceptedQuest();

            }

        });

        inv = FindObjectOfType<HotbarCollect>().itemslots;
        talkNPC.SetActive(false);
        endConversation.SetActive(false);
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
            QuestManager.instance.MarkQuestComplete(currentActiveQuest);
            ReceiveRewardAndCompleteQuest();
        }

        if (talkQuest)
        {
            if (true)
            {

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
        if (collider.gameObject == talkNPC)
        {
            ReceiveRewardAndCompleteQuest();
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
