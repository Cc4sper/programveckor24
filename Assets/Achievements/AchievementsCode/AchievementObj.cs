using System;
using Unity.VisualScripting;
using UnityEngine;

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
    public bool achievedLVL1;
    public bool achievedLVL2;
    public bool achievedLVL3;
    public bool isUpgradeable;
    [Header("Int Goal")]
    public int achGoal;
    public int level1Goal, level2Goal, level3Goal;

    public virtual bool Check()
    {
        bool value = false;
        Level = 0;

        if (achGoal >= level1Goal)
        {
            if (achievedLVL1 == false)
            {
                value = true;
            }
            achievedLVL1 = true;
            Level = 1;
            
        }
            if (isUpgradeable == true)
            {

                if (achGoal >= level2Goal)
                {
                if(achievedLVL2 == false)
                {
                    value = true;
                }
                    achievedLVL2 = true;
                    Level = 2;
                if (achGoal >= level3Goal)
                    {
                    if (achievedLVL3 == false)
                    {
                        value = true;
                    }
                        achievedLVL3 = true;
                        Level = 3;
                }
                }
            }
        return value;
    }
}
