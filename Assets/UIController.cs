using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{ 
    public Slider _musicSlider, _sfxSlider;

    public void Start()
    {  
         _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        _sfxSlider.value= PlayerPrefs.GetFloat("SFXVolume", 1);
        Debug.Log(_sfxSlider.value);
        
        
    }
    public void ToggleMusic() 
    {
        AudioManager.Instance.ToggleMusic();//S�tter p�/av music
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();//S�tter p�/av SFX
    }
    public void musicVolume() //�ndrar music volym efter slider value.
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        AudioPrefs();
        
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
        AudioPrefs();
    }
    public void AudioPrefs()
    {
        PlayerPrefs.SetFloat("SFXVolume", _sfxSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
    }
}
