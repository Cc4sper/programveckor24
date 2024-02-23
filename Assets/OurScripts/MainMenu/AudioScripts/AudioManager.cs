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

    // Awake method to handle the creation and persistence of the AudioManager instance.
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

    // PlaySFX method to play a sound effect by name.
    public void PlaySFX(string name)
    {
        // Find the Sound object with the given name in the sfxSounds array
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        // If the sound is not found, log an error message
        if (s == null)
        {
            Debug.Log("Sound not found for name: " + name);
        }
        else
        {
            // Play the found sound's clip using PlayOneShot
            sfxSource.PlayOneShot(s.clip);
        }
    }

    // SFXVolume method to set the volume of the sound effects.
    public void SFXVolume(float value)
    {
        // Set the volume of the sfxSource to the specified value
        sfxSource.volume = value;
    }
}
