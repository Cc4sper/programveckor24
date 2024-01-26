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
    [Header("Name/desc")]
    public string achName;
    public string description;
    public TextMeshProUGUI achText;
    [Header("Image/gameObj")]
    public Sprite sprite;
    public GameObject achObject;
    [Header("Achieved")]
    public bool Achieved;
    public Func<bool> condition;
}

public class AchievementsManager : MonoBehaviour
{
    public List<AchievementsGet> achievements;

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
            }
        }
    }

    public void UnlockAchievement(AchievementsGet achievement)
    {
        achievement.Achieved = true;
        Debug.Log("Achievement unlocked: " + achievement.achName);
    }
    void UpdateConditions()
    {
        // Update conditions here if needed
        // Example:
        achievements[0].condition = () => Input.GetKeyDown(KeyCode.W);
        achievements[1].condition = () => Input.GetKeyDown(KeyCode.S);
    }
    public void UpdateAchivementUI()
    {
        foreach (AchievementsGet achievement in achievements)
        {
            if (achievement.achText != null)
            {
                if (achievement.Achieved)
                    achievement.achText.text = "Has been unlocked: " + achievement.achName + "\nDescription: " + achievement.description;
                else
                    achievement.achText.text = "Hasn't been unlocked: " + achievement.achName + "\nDescription: " + achievement.description;
            }
        }
    }

}