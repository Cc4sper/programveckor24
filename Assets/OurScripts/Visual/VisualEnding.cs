using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEnding : MonoBehaviour
{
    [SerializeField] GameObject[] disable;
    [SerializeField] DarkScreen screen;
    [SerializeField] GameObject player;
    [SerializeField] float wait;
    [SerializeField] float waitFade;
    float timer;
    private void OnEnable()
    {
        timer = wait;
    }
    private void Update()
    {
        if (timer < waitFade)
        {
            print("fade ending");
            waitFade = wait;
            screen.speed = 0.2f;
            screen.ScreenFade(false);
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else 
        {
            print("enable ending");
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].SetActive(false);
            }
            GetComponent<opening>().enabled = true;
            player.GetComponent<PlayerHealth>().DisablePlayer();
        }
    }
}
