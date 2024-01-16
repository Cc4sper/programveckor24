using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="Data", menuName = "ScriptableObjects/QuestInfo", order = 1)]
public class QuestInfo : ScriptableObject
{

    [Header("Rewards")]
    public GameObject rewardItem1;
    public GameObject rewardItem2;

    [Header("Requirements")]
    public GameObject firstRequirmentItem;
    public GameObject secondRequirmentItem;
}