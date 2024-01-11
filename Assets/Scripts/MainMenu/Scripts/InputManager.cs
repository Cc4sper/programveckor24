using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI ButtonForwards;
    [SerializeField] private TextMeshProUGUI buttonBackWards;
    [SerializeField] private TextMeshProUGUI buttonDash;

    public void Start()
    {
        ButtonForwards.text = PlayerPrefs.GetString("CustomKey");
    }
    private void Update()
    {
        if(ButtonForwards.text == "Awaiting Input")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    ButtonForwards.text = keycode.ToString();
                    PlayerPrefs.SetString("CustomKey", keycode.ToString());
                    PlayerPrefs.Save();
                }
            }
        }
    }
    public void ChangeKey()
    {
        ButtonForwards.text = "Awaiting Input";
    }
}
