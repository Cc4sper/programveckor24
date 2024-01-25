using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
[System.Serializable]
public class AchivementsGet {
    [Header("Name/desc")]
    public string achName;
    public string description;
    public TextMeshProUGUI achText;
    [Header("Image/gameObj")]
    public Sprite sprite;
    public GameObject achObject;
    [Header("Achieved")]
    public bool Achieved;
}

public class AchivementManager : MonoBehaviour
{
    public AchivementsGet[] AchievementsElement;

    void Start()
    {
        // Access and print information about each achievement
        foreach (AchivementsGet achievement in AchievementsElement)
        {
            Debug.Log("Achievement: " + achievement.achName + ", Description: " + achievement.description + ", Unlocked: " + achievement.Achieved);
        }
    }
    public void Update()
    {
        UpdateAchivementUI();
    }
    public void UpdateAchivementUI()
    {
        foreach (AchivementsGet achievement in AchievementsElement)
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