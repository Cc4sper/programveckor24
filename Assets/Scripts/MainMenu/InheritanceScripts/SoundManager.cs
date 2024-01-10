using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider; //L�gger till "slider" i unity inspector
    [SerializeField] Slider soundEffectsSlider;
    [Header("Audio Sources")]                                     
    [SerializeField] AudioSource musicVolume;
    [SerializeField] AudioSource soundEffects;

    public void Start()
    {
       
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
        musicVolume.volume = musicVolumeSlider.value; //V�rat in-game audio blir justerat efter "volumeSlider value" 
        Save();
        soundEffects.volume = soundEffectsSlider.value;

    }


    public void Save() //Anv�nds f�r att spara spelarens preferns volym.
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);//Sparar spelarens personliga val av volym. Den blir sparad i "musicVolume" och efter valuen av "volumeSlider".
    }

    public void Load() //Anv�nds for att ladda sparad volym
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume"); //H�mtar PlayerPrefs "musicVolume" som s�tter valuen som blev sparad i functionen "Save".
    }
}
