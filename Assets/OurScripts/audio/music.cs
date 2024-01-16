using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        StartCoroutine(Fade(true, source, 2f, 1f));
        StartCoroutine(Fade(false, source, 2f, 0f));
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            source.Play();
            StartCoroutine(Fade(true, source, 2f, 1f));
            StartCoroutine(Fade(false, source, 2f, 0f));
        }
    }

    public IEnumerator Fade(bool fadeIn,AudioSource source,float duration,float targetVolume)
    {
        if (!fadeIn)
        {
            double lenghtOfsource = (double)source.clip.samples / source.clip.frequency;
            yield return new WaitForSecondsRealtime((float)(lenghtOfsource - duration));
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

        yield break;
    }
}
