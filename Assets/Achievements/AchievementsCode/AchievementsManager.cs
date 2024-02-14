using System.Collections.Generic;
using UnityEngine;
public class AchievementsManager : MonoBehaviour
{
    public GameObject popUp;
    public List<AchievementObj> achievements;
    public void Start()
    {
        popUp.SetActive(false);
    }
    public void Update()
    {
        UpdateConditions();
    }
    void UpdateConditions()
    {
        for (int i = 0; i < achievements.Count; i++)
        {
            if (achievements[i].Check())
            {
                AchPopUp(achievements[i].achName, achievements[i].Level);
            } 
        }
    }

    public void AchPopUp(string achName, int level)
    {
        //visa popup
        //använd parametrar för relevant info
    }
}