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
    float timer;
    Vector3 ogPos;
    int rando = 2;
    bool first = true;

    private void Start()
    {
        SetTarget();
    }

    void Update()
    {

        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
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
            target = new Vector3(player.position.x,transform.position.y,0); 
        }
        else if (x == 1)
        {
            target = new Vector3(transform.position.x, player.position.y, 0);
        }
        else if (x == 2)
        {
            target = new Vector3(player.position.x, player.position.y);
        }
        
        
        
    }

}
