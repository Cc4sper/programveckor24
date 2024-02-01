using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 3;
    public Transform enemy;
    private Transform target;
    public Animator animator;



    public void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
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
            transform.parent.GetComponent<RandomMovement>().enabled = false;
            target = collision.transform;
            animator.SetFloat("x", collision.transform.position.x - transform.position.x);
            animator.SetFloat("y", collision.transform.position.y - transform.position.y);

            print("chasing player");
            

        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            transform.parent.GetComponent<RandomMovement>().enabled = true;
            target = null;

            print("lost chase");

        }
    }


   

}