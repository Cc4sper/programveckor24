using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; //L�gger till "slider" i unity inspector
    Text percentageText;

    public void Start()
    {
        percentageText = GetComponent<Text>();
        if (!PlayerPrefs.HasKey("musicVolume"))//Om inga value har blivit sparad som "musicVolume" s� h�nder functionen.
        {
            PlayerPrefs.SetFloat("musicVolume",1); //S�tter PlayerPref value till 1.
            Load(); //Activera functionen Load. Functionen �ndrar spelarens volym till PlayerPref "musicVolume" i alla scener.
        }
        else
        {
            Load(); //Activerar function Load. 
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value; //V�rat in-game audio blir justerat efter "volumeSlider value" 
        Save();

    }


    public void Save() //Anv�nds f�r att spara spelarens preferns volym.
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);//Sparar spelarens personliga val av volym. Den blir sparad i "musicVolume" och efter valuen av "volumeSlider".
    }

    public void Load() //Anv�nds for att ladda sparad volym
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume"); //H�mtar PlayerPrefs "musicVolume" som s�tter valuen som blev sparad i functionen "Save".
    }

    public void TextUpdater(float value) //anv�nds f�r att updatera text.
    {
        percentageText.text = Mathf.RoundToInt(value * 100) + "%";//Updaterar text f�r att efterliknad value, avrundar den till n�rmsta heltal och tar g�nger 100 f�r att f� 1-100.
    }
}
