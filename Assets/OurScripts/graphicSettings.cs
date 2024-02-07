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
        fullscreenToggle.isOn = !fullscreenToggle.isOn;
    }
    public void ResolutionLeft()
    {
        if (selectedRes > 0)
        {
            selectedRes--;
            Debug.Log(selectedRes);
        }
        resText.text = resolutions[selectedRes].width + "x" + resolutions[selectedRes].height;
    }
    public void ResolutionRight()
    {
        if (selectedRes < resolutions.Length-1)
        {
            selectedRes++;
            Debug.Log(selectedRes);
        }
        resText.text = resolutions[selectedRes].width + "x" + resolutions[selectedRes].height;
        
    }
    public void SetResolution()
    {
        Screen.SetResolution(resolutions[selectedRes].width, resolutions[selectedRes].height, fullscreenToggle.isOn);
        print(resolutions[selectedRes].width);
    }
    public void ApplyRes()
    {

    }
}
