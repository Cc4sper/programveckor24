using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TmpUpdateTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText;

    public void SliderChange(float value)
    {
        sliderText.text = value.ToString("0%"); //visar value av slidern som 0%-100%.
    }
}
