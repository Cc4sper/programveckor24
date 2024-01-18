using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosstrigger : MonoBehaviour
{
     [SerializeField] GameObject border, madam;
    Transform player; 
    Camera cam;
    float timer;
    bool triggered;
    float a;
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && triggered == false)
        {
            triggered = true;
            border.SetActive(true);
            player = collision.transform.parent;
            cam = player.GetComponent<PlayerCamera>().cam;
            cam.GetComponent<Camerafollow>().target = madam.transform;
            timer = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            a += Time.deltaTime;
            madam.GetComponent<SpriteRenderer>().color = new Color(a*0.5f, a*0.5f, a*0.5f, 1);
            madam.transform.position += new Vector3(0, -Time.deltaTime) *2; 
        }
        else if (triggered == true)
        {
            triggered = false;
            cam.GetComponent<Camerafollow>().target = player.transform;
            //madam.transform.position += new Vector3(0, -6);
            madam.GetComponent<StraightChase>().enabled = true;
            madam.GetComponent<BossHealth>().enabled = true;
        }
        else if (madam == null)
        {
            Destroy(border);
            Destroy(gameObject);
        }
       
    }
}
