using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource source;
    [SerializeField] AudioClip Tempclip;
    [SerializeField] AudioClip newclip;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        StartCoroutine(FadeMusic(true, source, 2f, 1f));
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            source.Play();
            StartCoroutine(FadeMusic(true, source, 2f, 1f));
        }
        if (Input.GetKey(KeyCode.M))
        {
            Repeat();
        }
    }

    private IEnumerator FadeMusic(bool fadeIn,AudioSource source,float duration,float targetVolume)
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
        if (newclip != null)
        {
            source.clip = newclip;
        }
        yield break;
    }

    public void Repeat()
    {
        source.volume = 0f;
        source.Play();
        StartCoroutine(FadeMusic(true, source, 2f, 1f));
    }

    public void SwitchMusic(AudioClip newClip)
    {
        StartCoroutine(FadeMusic(false, source, 0.2f, 0f));
        newclip = newClip;
    }
}
