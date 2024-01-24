using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostProcessEdit : MonoBehaviour
{
    private Bloom bl;
    private ColorGrading co;
    private PostProcessVolume post;
    
    // Start is called before the first frame update
    void Start()
    {
        
        post = GetComponent<PostProcessVolume>();
        post.profile.TryGetSettings(out bl);
        post.profile.TryGetSettings(out co);
    }

    public void ChangeBloom(int newVal)
    {
        bl.intensity.value = newVal;
    }
    public void ChangeTemprature(int newVal)
    {
        co.temperature.value = newVal;
    }
}
