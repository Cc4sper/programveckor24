using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFade : MonoBehaviour
{
    public bool fade = false;
    SpriteRenderer sprite;
    public float alpha = 1;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            alpha -= Time.deltaTime;
            sprite.color = new Color(1, 1, 1, alpha);
        }
        else if (alpha < 1)
        {
            alpha += Time.deltaTime;
            sprite.color = new Color(1, 1, 1, alpha);
        }
        else if (!GetComponent<BoxCollider2D>().enabled)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
