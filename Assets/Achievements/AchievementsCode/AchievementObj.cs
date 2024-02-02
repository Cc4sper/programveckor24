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
    public string progressBardDescription;
    public int Level;
    [Header("Achieved/Upgrade")]
    public bool Achieved;
    public bool isUpgradeable;
    public Func<bool> condition;
    [Header("Kills")]
    public int achGoal;
    public int level1Goal, level2Goal, level3Goal;

    public virtual void Check()
    {

    }
}

[CreateAssetMenu]
public class KillAchievement : AchievementObj
{
    public override void Check()
    {
        if (achGoal >= level1Goal)
        {
            Achieved = true;
            Level = 1;

            if (achGoal >= level2Goal)
            {
                Level = 2;
                
                if (achGoal >= level3Goal)
                {
                    Level = 3;
                    
                }
            }
        }
        else
        {
            Level = 0;
        }
    }
}
