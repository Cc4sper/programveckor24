using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AchivementManager : MonoBehaviour
{
    public List<Achivement> achivements;

    public int integer;
    public float floating_point;

    public void Start()
    {
        InitalizeAchivements();
    }

    private void InitalizeAchivements()
    {
        if (achivements != null)
            return;
        achivements = new List<Achivement>();
        achivements.Add(new Achivement("Step by step", "Set your integer to or over 100", (object o) => integer <= 100));
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
        Debug.Log($"{title}: |{description}");
        achieved = true;
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}
