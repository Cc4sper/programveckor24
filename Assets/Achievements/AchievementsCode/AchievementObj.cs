using System;
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

    public virtual void Check()
    {
        Level = 0;
        achievedLVL1 = false;
        achievedLVL2 = false;
        achievedLVL3 = false;

        if (achGoal >= level1Goal)
        {
            achievedLVL1 = true;
            Level = 1;
        }
            if (isUpgradeable == true)
            {

                if (achGoal >= level2Goal)
                {
                    achievedLVL2 = true;
                    Level = 2;

                    if (achGoal >= level3Goal)
                    {
                        achievedLVL3 = true;
                        Level = 3;

                    }
                }
            }
        }
    }


[CreateAssetMenu]
public class KillAchievement : AchievementObj
{
    public override void Check()
    {
        isUpgradeable = true;
        base.Check();
    }
}
[CreateAssetMenu]
public class JustPressW : AchievementObj
{

    public override void Check()
    {
        isUpgradeable = false;
        base.Check();

        if (Input.GetKeyDown(KeyCode.W))
        {
            achGoal += 1;
        }
    }
}
