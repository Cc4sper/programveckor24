using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 3;
    public Transform enemy;
    private Transform target;
    



    public void Start()
    {
        enemy = transform.parent.transform;
    }

    
    public virtual void Update()
    {

       
        
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            enemy.position = Vector2.MoveTowards(transform.position, target.position, step);
           
        }

    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            target = collision.transform;

            print("chasing player");
            

        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            target = null;

            print("lost chase");

        }
    }


   

}