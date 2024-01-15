using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI[] buttonChangers; // Text elements for displaying key bindings
    private int currentButtonIndex = 0;

    public void Start()
    {
        // Ladda sparade tangenter för alla knappar
        for (int i = 0; i < buttonChangers.Length; i++)
        {
            LoadKey(i);
        }
    }

    private void Update()
    {
        if (buttonChangers[currentButtonIndex].text == "Awaiting Input")
        {
            // Loopa igenom alla möjliga tangenter och kolla om någon av dem är nedtryckt
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    // Uppdatera texten för den aktuella knappen och spara den nya tangen
                    buttonChangers[currentButtonIndex].text = keycode.ToString();
                    SaveKey(currentButtonIndex, keycode.ToString());
                    // Gå till nästa knapp och ladda dess sparade tangent
                    currentButtonIndex = (currentButtonIndex + 1) % buttonChangers.Length;
                    LoadKey(currentButtonIndex);
                }
            }
        }
    }

    public void ChangeKey(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttonChangers.Length)
        {
            // Återställ texten för den valda knappen och sätt dess index som det aktuella indexet
            buttonChangers[buttonIndex].text = "Awaiting Input";
            currentButtonIndex = buttonIndex;
        }
        else
        {
           
            Debug.LogError("Invalid button index");
        }
    }

    private void SaveKey(int buttonIndex, string key)
    {
        // Spara den valda tangen för knappen i spelarens inställningar
        PlayerPrefs.SetString("CustomKey" + buttonIndex, key);
        if (buttonIndex == 0)
        {
            print("sparar höger input som " + key);
        }
        PlayerPrefs.Save();
    }

    private void LoadKey(int buttonIndex)
    {
        // Ladda den sparade tangen för den aktuella knappen och uppdatera dess text
        string key = PlayerPrefs.GetString("CustomKey" + buttonIndex, "");  
        buttonChangers[buttonIndex].text = key;
    }
}
