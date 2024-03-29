using Ink.Runtime;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{ 
    public Slider musicSlider, sfxSlider;


    public void Update()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);   
        sfxSlider.value= PlayerPrefs.GetFloat("SfxVolume", 1);
    }
    public void MusicVolume() //�ndrar music volym efter slider value.
        
    {
        music.Instance.MusicVolume(musicSlider.value);
        MusicPrefs();
    }


    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sfxSlider.value);
        SfxPrefs();

    }
    public void MusicPrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
    public void SfxPrefs()
    {
        PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
    }
}
