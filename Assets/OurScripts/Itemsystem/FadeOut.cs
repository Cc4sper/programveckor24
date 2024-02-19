using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] float fadeSpeed = 1;
    float alphaVal;
    float r, b, g;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        r = sprite.color.r;
        b = sprite.color.b;
        g = sprite.color.g;
        alphaVal = sprite.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        alphaVal -= Time.deltaTime * fadeSpeed;
        sprite.color = new Color(r, g, b, alphaVal);
    }
}
