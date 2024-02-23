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

    // The main Update method, called every frame.
    public void Update()
    {
        AchLevelDsiplay();  // Update achievement level display
        AchUTextUpdater();  // Update achievement text
        AchProgresBarsDisplay();  // Update progress bars display
    }

    // Update achievement text based on achievement properties.
    public void AchUTextUpdater()
    {
        if (achObj != null)
        {
            // Construct the achievement text string
            achText.text = $"Achievement: {achObj.achName}     level: {achObj.Level}                          Description: {achObj.description}";

            // Check if the achievement is upgradeable
            if (achObj.isUpgradeable == true)
            {
                // If the goal is greater than the level 3 goal, display "Max level"
                if (achObj.achGoal > achObj.level3Goal)
                {
                    achText.text = $"Achievement: {achObj.achName}     level: {maxLevel}                      Description: {achObj.description}";
                }
            }
            else
            {
                // If the goal is greater than the level 1 goal, display "Max level"
                if (achObj.achGoal > achObj.level1Goal)
                {
                    achText.text = $"Achievement: {achObj.achName}     level: {maxLevel}                      Description: {achObj.description}";
                }
            }
        }
    }

    // Update achievement icon based on achievement level and upgradeability.
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

    // Update progress bars based on achievement properties.
    public void AchProgresBarsDisplay()
    {
        if (achObj != null)
        {
            if (achObj.Level == 0)
            {
                // Calculate and set the percentage for the progress bar
                float percenetage = (float)achObj.achGoal / (float)achObj.level1Goal;
                achProgress.value = percenetage;

                // Set the progress bar count text and color based on the percentage
                count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level1Goal} ";
                fillArea.color = Color.Lerp(Color.white, Color.green, percenetage);
            }
            else if (achObj.isUpgradeable == false)
            {
                // Calculate and set the percentage for the progress bar
                float percenetage = (float)achObj.achGoal / (float)achObj.level1Goal;
                achProgress.value = percenetage;

                // Set the progress bar count text and color based on the percentage
                count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level1Goal} ";
                fillArea.color = Color.Lerp(Color.white, Color.yellow, percenetage);
            }

            if (achObj.isUpgradeable == true)
            {
                // Different cases for upgradeable achievements

                if (achObj.Level == 1)
                {
                    // Calculate and set the percentage for the progress bar
                    float percenetage = (float)achObj.achGoal / (float)achObj.level2Goal;
                    achProgress.value = percenetage;

                    // Set the progress bar count text and color based on the percentage
                    count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level2Goal} ";
                    fillArea.color = Color.Lerp(Color.white, Color.red, percenetage);
                }
                else if (achObj.achGoal >= achObj.level2Goal && achObj.achGoal <= achObj.level3Goal)
                {
                    // Calculate and set the percentage for the progress bar
                    float percenetage = (float)achObj.achGoal / (float)achObj.level3Goal;
                    achProgress.value = percenetage;

                    // Set the progress bar count text and color based on the percentage
                    count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/{achObj.level3Goal} ";
                    fillArea.color = Color.Lerp(Color.white, Color.yellow, percenetage);
                }
                else if (achObj.achGoal > achObj.level3Goal)
                {
                    // Calculate and set the percentage for the progress bar
                    float percenetage = (float)achObj.achGoal / (float)achObj.level3Goal;
                    achProgress.value = percenetage;

                    // Set the progress bar count text and color based on the percentage
                    count.text = $"{achObj.progressBardDescription} {achObj.achGoal}/∞ ";
                    fillArea.color = Color.Lerp(Color.white, Color.yellow, percenetage);
                }
            }
            else
            {
                // Case for non-upgradeable achievements with goal greater than level 1
                if (achObj.achGoal > achObj.level1Goal)
                {
                    // Calculate and set the percentage for the progress bar
                    float percenetage = (float)achObj.achGoal / (float)achObj.level3Goal;
                    achProgress.value = percenetage;

                    // Set the progress bar count text and color based on the percentage
                    count.text = $"{maxLevel}";
                    fillArea.color = Color.Lerp(Color.white, Color.yellow, percenetage);
                }
            }
        }
    }
}
