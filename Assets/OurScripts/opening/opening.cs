using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opening : MonoBehaviour
{
    [SerializeField] float time;
    int ontext = 0;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = time;
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
            nexttext();
            timer = time;
        }

    }
    void nexttext()
    {
        transform.GetChild(ontext).gameObject.SetActive(false);
        ontext++;
        transform.GetChild(ontext).gameObject.SetActive(true);
    }
}
