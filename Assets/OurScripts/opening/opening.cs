using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opening : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject sand;
    int ontext = 0;
    float timer;
    [SerializeField] float speed;
    Vector3 savedPos;
    bool reseted = true;
    // Start is called before the first frame update
    void Start()
    {
        timer = time;
        transform.position = savedPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            print("reset time");
            timer = time;
        }
        if (timer < 2)
        {
            sandMove();
        }
        if (timer < 0.5 && reseted)
        {
            print("reset sand");
            resetSan();
        }
        if (timer < 1)
        {
            nexttext();
        }
    }
    void sandMove()
    {
        sand.transform.position += new Vector3(speed, 0)*Time.deltaTime;
    }
    void resetSan()
    {
        reseted = false;
        sand.transform.position -= new Vector3(1000, 0);
    }
    void nexttext()
    {
        transform.GetChild(ontext).gameObject.SetActive(false);
        ontext++;
        transform.GetChild(ontext).gameObject.SetActive(true);
        reseted = true;
    }
}
