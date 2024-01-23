using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] sfxSounds;
    public AudioSource sfxSource;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found, fuck me");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void SFXVolume(float value)
    {
        sfxSource.volume = value;
    }
}