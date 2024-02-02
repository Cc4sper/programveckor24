using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class AchievementObj : ScriptableObject
{
    [Header("Name/Desc/LVL")]
    public string achName;
    public string description;
    public string showDescription;
    public int Level;
    [Header("Achieved/Upgrade")]
    public bool Achieved;
    public bool isUpgradeable;
    public Func<bool> condition;
    [Header("Kills")]
    public Color levelColour;
    public int currentKill;



    public virtual void Check()
    {

    }

}

[CreateAssetMenu]
public class KillAchievement : AchievementObj
{

    [SerializeField]
    int level1Goal, level2Goal, level3Goal;

    public override void Check()
    {
        showDescription = "Kill" + currentKill;
        if (currentKill >= level1Goal)
        {
            Achieved = true;
            Level = 1;
            levelColour = Color.green;

            if (currentKill >= level2Goal)
            {
                Level = 2;
                levelColour = Color.red;
                if (currentKill >= level3Goal)
                {
                    Level = 3;
                    levelColour = Color.yellow;
                }
            }
        }
    }
}
