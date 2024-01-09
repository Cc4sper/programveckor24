using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; //Lägger till "slider" i unity inspector
    Text percentageText;

    public void Start()
    {
        percentageText = GetComponent<Text>();
        if (!PlayerPrefs.HasKey("musicVolume"))//Om inga value har blivit sparad som "musicVolume" så händer functionen.
        {
            PlayerPrefs.SetFloat("musicVolume",1); //Sätter PlayerPref value till 1.
            Load(); //Activera functionen Load. Functionen ändrar spelarens volym till PlayerPref "musicVolume" i alla scener.
        }
        else
        {
            Load(); //Activerar function Load. 
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value; //Vårat in-game audio blir justerat efter "volumeSlider value" 
        Save();

    }


    public void Save() //Används för att spara spelarens preferns volym.
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);//Sparar spelarens personliga val av volym. Den blir sparad i "musicVolume" och efter valuen av "volumeSlider".
    }

    public void Load() //Används for att ladda sparad volym
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume"); //Hämtar PlayerPrefs "musicVolume" som sätter valuen som blev sparad i functionen "Save".
    }

    public void TextUpdater(float value) //används för att updatera text.
    {
        percentageText.text = Mathf.RoundToInt(value * 100) + "%";//Updaterar text för att efterliknad value, avrundar den till närmsta heltal och tar gånger 100 för att få 1-100.
    }
}
