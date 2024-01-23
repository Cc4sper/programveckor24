using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public SpriteRenderer sprite;
    public int enemyhp;
    public float recoverTime;
    public float timer;
    public bool vulnerable = true;
    public bool chaser;
    public float ogSpeed;
    

    public void Start()
    {
        if (chaser)
        {
            ogSpeed = transform.GetChild(1).GetComponent<EnemyChase>().speed;
        }
        sprite = GetComponent<SpriteRenderer>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("damage") && vulnerable)
        {
            TakeDamage(collision.transform.GetComponent<GenericAttack>().damage, true);
        }
    }
   
    public virtual void TakeDamage(int dmg, bool hit)
    {
        vulnerable = false;
        print("hit enemy " + dmg);
        enemyhp -= dmg;
        checkkdeath();

        sprite.color = new Color(0.9f, 0.9f, 0.9f, 1);
        
        if (hit && chaser)
        {
            transform.GetChild(1).GetComponent<EnemyChase>().speed = 0;
        }
        timer = recoverTime;
    }
    public virtual void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Recover();
        }
    }
    public void Recover()
    {
        vulnerable = true;
        sprite.color = Color.white;
        if (chaser)
        {
            transform.GetChild(1).GetComponent<EnemyChase>().speed = ogSpeed;
        }
    }
    public void checkkdeath()
    {
        if (enemyhp < 1)
        {
            GetComponent<EnemyLootDrop>().DropLoot();
            Destroy(gameObject);
        }
    }
}
