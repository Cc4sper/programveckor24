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
    public List<AchievementObj> achievements;

    void Start()
    {
        
    }
    public void Update()
    {
        UpdateConditions();
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
        for (int i = 0; i < achievements.Count; i++)
        {
            achievements[i].Check();
        }
    }
}