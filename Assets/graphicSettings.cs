using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class graphicSettings : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public ResolutionChanger[] resolutions;
    public int selectedRes;
    public TextMeshProUGUI resText;
    public void ApplyFullcreen()
    {
        if (fullscreenToggle.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
    public void ResolutionLeft()
    {
        if (selectedRes > 0)
        {
            selectedRes--;
        }
        resText.text = resolutions[selectedRes].width + "x" + resolutions[selectedRes].height;
    }
    public void ResolutionRight()
    {
        if (selectedRes < resolutions.Length-1)
        {
            selectedRes++;
        }
        resText.text = resolutions[selectedRes].width + "x" + resolutions[selectedRes].height;
        SetResolution();
    }
    public void SetResolution()
    {
        Screen.SetResolution(resolutions[selectedRes].width, resolutions[selectedRes].height, fullscreenToggle.isOn);
    }
    public void ApplyRes()
    {

    }
}
