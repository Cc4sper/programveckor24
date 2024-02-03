using System.Collections.Generic;
using UnityEngine;
public class AchievementsManager : MonoBehaviour
{
    public List<AchievementObj> achievements;

    public void Update()
    {
        UpdateConditions();
    }
    void UpdateConditions()
    {
        for (int i = 0; i < achievements.Count; i++)
        {
            achievements[i].Check();
        }
    }
}