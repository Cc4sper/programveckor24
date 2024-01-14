using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    Image sprite;
    [SerializeField] float speed;
    bool fadeIn;
    float alpha = 0;
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
            }
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

    public void ScreenFade()
    {
        fadeIn = true;
    }
}
