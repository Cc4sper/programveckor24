using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    Image sprite;
    public float speed;
    [SerializeField] float alpha = 0;
    [SerializeField] float stayDark;
    [SerializeField] bool clear;
    float stayTimer;
    bool fadeIn;
    
    private void Start()
    {
        sprite = GetComponent<Image>(); 
    }
    void Update()
    {
        if (fadeIn)
        {
            if (alpha < 1)
            {
                ChangeAlpha(speed);
            }
            else
            {
                fadeIn = false;
                stayTimer = stayDark;
            }
        }
        else if (stayTimer > 0)
        {
            print("stay");
            stayTimer -= Time.deltaTime;
        }
        else if (alpha > 0)
        {
            ChangeAlpha(-speed);
        }
    }

    void ChangeAlpha(float x)
    {
        sprite.color = new Color(0, 0, 0, alpha);
        alpha += Time.deltaTime * x;
    }

    public void ScreenFade(bool fadeOut)
    {
        clear = fadeOut;
        fadeIn = true;
    }
}
