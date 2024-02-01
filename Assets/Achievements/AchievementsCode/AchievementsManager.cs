using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


[System.Serializable]
public class AchievementsGet {
    [Header("Name/Desc/LVL")]
    public string achName;
    public string description;
    public string showDescription;
    public int Level;
    public TextMeshProUGUI achText;
    [Header("Sprite/AchIm")]
    public Sprite sprite;
    public Image achImage;
    [Header("Achieved/Upgrade")]
    public bool Achieved;
    public bool isUpgradeable;  
    public Func<bool> condition;
}

public class AchievementsManager : MonoBehaviour
{
    public List<AchievementsGet> achievements;
    public List<AchievementObj> test;

    void Start()
    {
        
    }
    public void Update()
    {
        UpdateConditions();
        CheckAchievements();
        UpdateAchivementUI();
    }
    void CheckAchievements()
    {
        for (int i = 0; i < achievements.Count; i++)
        {
            AchievementsGet achievement = achievements[i];

            // Check if the achievement is not achieved and the condition is not null
            if (!achievement.Achieved && achievement.condition != null)
            {
                // Check the condition
                if (achievement.condition.Invoke())
                {
                    // Unlock the achievement
                    UnlockAchievement(achievement);
                    Debug.Log("Achievement unlocked: " + achievement.achName);
                }
                if (achievement.isUpgradeable)
                {
                    
                }
            }
        }
    }

    

    public void UnlockAchievement(AchievementsGet achievement)
    {
        achievement.Achieved = true;
        Debug.Log("Achievement unlocked: " + achievement.achName + "\nDescription: " + achievement.showDescription);
        if (achievement.achImage != null)   
        {
            achievement.achImage.color = Color.yellow;
        }
    }
    void UpdateConditions()
    {
        for (int i = 0; i < test.Count; i++)
        {
            test[i].Check();
        }
    }
    public void UpdateAchivementUI()
    {
        foreach (AchievementsGet achievement in achievements)
        {
            if (achievement.achText != null)
            {
                if (achievement.Achieved)
                    achievement.achText.text = "Has been unlocked: " + achievement.achName + "\nDescription: " + achievement.showDescription;
                else
                    achievement.achText.text = "Hasn't been unlocked: " + achievement.achName + "\nDescription: " + achievement.description;
            }
        }
    }

}