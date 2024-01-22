using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIN : MonoBehaviour
{
    Image sprite;
    float alpha;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        alpha += Time.deltaTime;
        sprite.color = new Color(1, 1, 1, alpha);
        
    }
}
