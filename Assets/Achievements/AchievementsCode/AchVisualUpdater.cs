using TMPro;
using Unity.VisualScripting;
using UnityEngine;
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
    public Sprite maxIcon;
    [Header("Achievement & Manager")]
    public AchievementObj achObj;
    public AchievementsManager achievementsManager;

    [HideInInspector] public string maxLevel = "Max level";


     public void Update()
    {
        AchLevelDsiplay();
        AchUTextUpdater();  
        AchProgresBarsDisplay();
        AchPopUp();
    }

    public void AchUTextUpdater()
    {
        // Check if achievement is not null
        if (achObj != null)
        {
            achText.text = $"Achievement: {achObj.achName}     level: {achObj.Level}                          Description: {achObj.description}";
            if (achObj.isUpgradeable == true)
            {
                if (achObj.achGoal > achObj.level3Goal)
                {
                    achText.text = $"Achievement: {achObj.achName}     level: {maxLevel}                      Description: {achObj.description}";
                }
            } else
            {
                if (achObj.achGoal > achObj.level1Goal)
                {
                    achText.text = $"Achievement: {achObj.achName}     level: {maxLevel}                      Description: {achObj.description}";
                }
            }
        }
    }

    public void AchPopUp(string achName)
    {
        achName = achName + " has leveled up!";
    }

    public void AchLevelDsiplay()
    {
        if (achObj.Level <= 1)
        {
            achIconShows.sprite = achIcon1;
        }
        if (achObj.isUpgradeable == true)
        {
            if (achObj.Level == 2)
            {
                achIconShows.sprite = achIcon2;
            }
            else if (achObj.achGoal <= achObj.level3Goal && achObj.Level == 3)
            {
                achIconShows.sprite = achIcon3;
            }
            else if (achObj.achGoal > achObj.level3Goal)
            {
                achIconShows.sprite = maxIcon;
            }
        }
        else
        {
            if (achObj.achGoal > achObj.level1Goal)
            {
                achIconShows.sprite = maxIcon;
            }
        }
    }

    public void AchProgresBarsDisplay()
    {
        if (achObj != null)
        {
            if (achObj.Level == 0)
            {
                float percenetage = (float)achObj.achGoal / (float)achObj.level1Goal;
                achProgress.value = percenetage;

                count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level1Goal} ";

                fillArea.color = Color.Lerp(Color.white, Color.green, percenetage);
            }
            else if (achObj.isUpgradeable == false) 
            {
                float percenetage = (float)achObj.achGoal / (float)achObj.level1Goal;
                achProgress.value = percenetage;

                count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level1Goal} ";

                fillArea.color = Color.Lerp(Color.white, Color.yellow, percenetage);
            }
            if (achObj.isUpgradeable == true)
            {
                if (achObj.Level ==1)
                {
                    float percenetage = (float)achObj.achGoal / (float)achObj.level2Goal;
                    achProgress.value = percenetage;

                    count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level2Goal} ";

                    fillArea.color = Color.Lerp(Color.white, Color.red, percenetage);
                }
                else if (achObj.achGoal>= achObj.level2Goal && achObj.achGoal <= achObj.level3Goal)
                {
                    float percenetage = (float)achObj.achGoal / (float)achObj.level3Goal;
                    achProgress.value = percenetage;

                    count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level3Goal} ";

                    fillArea.color = Color.Lerp(Color.white, Color.yellow, percenetage);
                }
                else if (achObj.achGoal > achObj.level3Goal){
                    float percenetage = (float)achObj.achGoal / (float)achObj.level3Goal;
                    achProgress.value = percenetage;

                    count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/∞ ";

                    fillArea.color = Color.Lerp(Color.white, Color.yellow, percenetage);
                }
            } else
            {
                if (achObj.achGoal > achObj.level1Goal)
                {
                    float percenetage = (float)achObj.achGoal / (float)achObj.level3Goal;
                    achProgress.value = percenetage;

                    count.text = $"{maxLevel}";

                    fillArea.color = Color.Lerp(Color.white, Color.yellow, percenetage);
                }
            }
        }
    }
} 