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
    public string rewardItem1;
    public string rewardItem2;

    [Header("Requirements")]
    public string firstRequirmentItem;
    public int firstRequirementAmount;

    public string secondRequirmentItem;
    public int secondRequirementAmount;
}