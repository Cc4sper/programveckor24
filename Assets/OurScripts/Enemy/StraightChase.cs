using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightChase : MonoBehaviour
{
    public float speed = 3;
    public float range;
    public Vector3 target;
    public Transform player;
    public float cooldownCharge;
    Animator animate;
    float timer;
    Vector3 ogPos;
    int rando = 2;
    bool first = true;
    

    private void Start()
    {
        animate = GetComponent<Animator>();
        SetTarget();
    }

    void Update()
    {

        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            if (transform.position == target)
            {
                print("got to target");
                animate.SetBool("move", false);
                animate.SetFloat("x", 0);
                animate.SetFloat("y", 0);
            }
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SetTarget();
        }
    }
    public void nextPhase()
    {
        cooldownCharge *= 0.5f;
        speed = 8;
        rando = 3;
    }
    void SetTarget()
    {
        animate.SetBool("move", true);
        timer = cooldownCharge;
        int x = Random.Range(0, rando);
        if (first)
        {
            rando = 1;
            if (rando == 1)
            {
                rando = 2;
                first = false;
            }
        }
        if (x == 0)
        {
            animate.SetFloat("x", player.position.x - transform.position.x);
            target = new Vector3(player.position.x,transform.position.y,0); 
        }
        else if (x == 1)
        {
            animate.SetFloat("y", player.position.y - transform.position.y);
            target = new Vector3(transform.position.x, player.position.y, 0);
        }
        else if (x == 2)
        {
            animate.SetFloat("y", player.position.x - transform.position.x);
            animate.SetFloat("x", player.position.y - transform.position.y);
            target = new Vector3(player.position.x, player.position.y);
        }
        
        
        
    }

}
