using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class AchivementManager : MonoBehaviour
{
    public List<Achivement> achivements;

    public int integer;
    public float floating_point;

    public bool AchivementUnlocked(String achivementName)
    {
        if (achivements == null)
            return false;

        Achivement[] achivementsArray = achivements.ToArray();
        Achivement a = Array.Find(achivementsArray, ach => achivementName == ach.title);

        return a != null && !a.achieved;
    }

    public void Start()
    {
        InitalizeAchivements();
    }

    private void InitalizeAchivements() //here's the achivements possible to get.
    {
        if (achivements != null)
            return;
        achivements = new List<Achivement>();
        achivements.Add(new Achivement("Press W", "Press the 'W' key", (object o) => Input.GetKeyDown(KeyCode.W)));
    }
    private void Update()
    {
        CheckAchivementCompletion();
    }
    private void CheckAchivementCompletion()
    {
        if (achivements == null)
            return;

        foreach (var achivement in achivements)
            if (!achivement.achieved)
                achivement.UpdateCompletion();
    }
}
public class Achivement
{
    public Achivement(string title, string description, Predicate<object> requirement)
    {
        this.title = title;
        this.description = description;
        this.requirement = requirement;
    }
    public string title;
    public string description;
    public Predicate<object> requirement;

    public bool achieved;

    public void UpdateCompletion()
    {
        if (RequirementsMet()) //Checks if reqiurements have been met
        {
            Debug.Log($"{title}: {description} - Achievement Unlocked!");
            achieved = true;
        }
        else
        {
            Debug.Log($"{title}: {description} - Achievement Locked.");
            achieved = false;
        }
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}
public class AchievementPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI achievementText;
    public Image achievementImage;

    public void ShowPopup(string description, Sprite image)
    {
        achievementText.text = description;
        achievementImage.sprite = image;
        popupPanel.SetActive(true);
        // You can add animation logic here if needed.
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}
