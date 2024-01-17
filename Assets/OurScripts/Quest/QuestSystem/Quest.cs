using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;
using UnityEngine.UI;

[System.Serializable]
public class Quest
{

    public string questName;
    public string questDescription;
    public string questRequirements;
    [Header("Bools")]
    public bool accepted;
    public bool isCompleted;

    public bool hasNoRequirements;

    [Header("Quest Info")]
    public QuestInfo info;

}
