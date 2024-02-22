using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource source;
    [SerializeField] AudioClip Tempclip;
    [SerializeField] AudioClip newclip;
    public static music Instance;
    float fadeSec = 2;
    public bool canSwitch = true; 


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

    private void Start() // G�r s� att ljudet startar p� noll i volym.
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        StartCoroutine(FadeMusic(true, source, fadeSec, PlayerPrefs.GetFloat("MusicVolume", 1)));
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            source.Play();
            StartCoroutine(FadeMusic(true, source, fadeSec, PlayerPrefs.GetFloat("MusicVolume",1)));
        }
    }

    private IEnumerator FadeMusic(bool fadeIn,AudioSource source,float duration,float targetVolume)
    // �ndrar musikens volym enligt duration till target volume.
    {
        if (!fadeIn)
        {
            double lenghtOfsource = (double)source.clip.samples / source.clip.frequency;
            yield return new WaitForSecondsRealtime((float)(duration));
        }

        float time = 0f;
        float startVol = source.volume;
        while (time < duration)
        {
            string fadeSituation = fadeIn ? "fadeIn" : "fadeOut";
            Debug.Log(fadeSituation);
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVolume, time / duration);
            yield return null;
        }
        if (newclip != null) // s� l�nge det nya klippet finns s� byter det till nytt klipp.
        {
            source.clip = newclip;
        }
        yield break;
    }

    public void Repeat() // startar om ljud klippet med en fade in.
    {
        source.volume = 0f;
        source.Play();
        StartCoroutine(FadeMusic(true, source, 2f, PlayerPrefs.GetFloat("MusicVolume",1))); 
    }

    public void SwitchMusic(AudioClip newClip, float duration) // anv�nds av andra koder n�r man ska �ndra musiken.
    {
        if (canSwitch == true)
        {
            StartCoroutine(FadeMusic(true, source, 1f, 0f));
            fadeSec = duration;
            newclip = newClip;
        }
    }
    public void MusicVolume(float value)
    {
      source.volume = value;
    }
}
