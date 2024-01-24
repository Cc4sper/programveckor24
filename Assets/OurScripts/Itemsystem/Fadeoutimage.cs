using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeoutimage : MonoBehaviour
{
    Image sprite;
    [SerializeField] float fadeSpeed = 1;
    float alphaVal;
    void Start()
    {
        sprite = GetComponent<Image>();
        alphaVal = sprite.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        alphaVal -= Time.deltaTime * fadeSpeed;
        sprite.color = new Color(1, 1, 1, alphaVal);
    }
}