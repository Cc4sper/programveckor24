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

public class AchVisualUpdater : MonoBehaviour
{
    public TextMeshProUGUI achText;
    public Image achImage;
    public Sprite achIcon;
    public AchievementObj achObj;

    public AchievementsManager achievementsManager;
    public void Update()
    {
        KCAchUTextUpdater();
    }

    public void KCAchUTextUpdater()
    {
        // Check if achievement is not null
        if (achObj != null)
        {
            // Update the achText with the generalized achievement details
            achText.text = $"";

            // If the achievement has additional specific information (e.g., kill count), include it
            if (achObj is KillAchievement killAchievement)
            {
                
                achText.text += $"Achievement: {achObj.achName}     Level: {achObj.Level}                       Description: {achObj.description} \nKill Count: {killAchievement.currentKill}"; 
            }
        }
    }

}
