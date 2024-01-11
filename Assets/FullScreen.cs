using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public void ScreenMinMax()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("Changed");
    }
}
