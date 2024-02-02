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
    [Header("TmpText & Image & IconShow")]
    public TextMeshProUGUI achText;
    public Image achImage;
    public SpriteRenderer achIconShows;
    [Header("ProgressBar")]
    public Slider achProgress;
    public TextMeshProUGUI count;
    public Image fillArea;
    [Header("Icons")]
    public Sprite achIcon1;
    public Sprite achIcon2;
    public Sprite achIcon3;
    [Header("Achievement & Manager")]
    public AchievementObj achObj;
    public AchievementsManager achievementsManager;

    [HideInInspector] public string maxLevel = "Max level";


     public void Update()
    {
        AchLevelDsiplay();
        KCAchUTextUpdater();  
        AchProgresBarsDisplay();
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
                achText.text += $"Achievement: {achObj.achName}     Level: {achObj.Level}                       Description: {achObj.description}";
                if (achObj.Level == 3)
                {
                    achText.text = $"Achievement: {achObj.achName}     Level: {maxLevel}                      Description: {achObj.description}";
                }
            }
        }
    }

    public void AchLevelDsiplay()
    {
        if (achObj.Level == 1)
        {
            achIconShows.sprite = achIcon1;
        } else if (achObj.Level == 2)
        {
            achIconShows.sprite = achIcon2;
        }
        else
        {
            achIconShows.sprite = achIcon3;
        }  
    }

    public void AchProgresBarsDisplay()
    {
        if (achObj != null)
        {

            if (achObj.Level < 1)
            {
                float percenetage = (float)achObj.achGoal / (float)achObj.level1Goal;
                achProgress.value = percenetage;

                count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level1Goal} ";

                fillArea.color = Color.Lerp(Color.white, Color.green, percenetage);
            }
            else if (achObj.Level >=1 && achObj.Level <3)
            {
                float percenetage = (float)achObj.achGoal / (float)achObj.level2Goal;
                achProgress.value = percenetage;

                count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level2Goal} ";

                fillArea.color = Color.Lerp(Color.white, Color.red, percenetage);
            }
            else if(achObj.Level == 3)
            {
                float percenetage = (float)achObj.achGoal / (float)achObj.level3Goal;
                achProgress.value = percenetage;

                count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/∞ ";

                fillArea.color = Color.Lerp(Color.white, Color.yellow, percenetage);
            }
        }
    }
} 
