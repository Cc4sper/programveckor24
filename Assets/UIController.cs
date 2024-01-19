using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{ 
    public Slider _musicSlider, _sfxSlider;

    public void Update()
    {  
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        _sfxSlider.value= PlayerPrefs.GetFloat("SfxVolume", 1);
    }
    public void ToggleMusic() 
    {
        AudioManager.Instance.ToggleMusic();//Sätter på/av music
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();//Sätter på/av SFX
    }
    public void MusicVolume() //Ändrar music volym efter slider value.
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        MusicPrefs();
        
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
        SfxPrefs();
    }
    public void MusicPrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
    }
    public void SfxPrefs()
    {
        PlayerPrefs.SetFloat("SfxVolume", _sfxSlider.value);
    }
}
