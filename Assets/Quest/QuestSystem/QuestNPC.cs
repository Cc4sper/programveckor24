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
    void Start()
    {
        informationNPC.SetActive(false);

    }

    void Update()
    {
        if (answerText.text == "Accept" && buttonPressed == true)
        {
            questActive = true;
            buttonPressed = false;
        }
        if (questActive == true)
        {
            // QuestManager.instance.AddActiveQuest(currentActiveQuest);
            informationNPC.SetActive(true);
        }


    }

    public void Button()
    {
        if (answerText.text == "Accept")
        {
            buttonPressed = true;
        }
    }

    /*
    private void AcceptedQuest()
    {
        currentActiveQuest.accepted = true;
        currentActiveQuest.declined = false;


    }
    */
}
