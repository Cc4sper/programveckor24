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
    

    public void Start() // ifall de �r en chaser s� h�mtar den orginella hastigheten.
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
    // Fienden tar skada och �ndrar f�rg, blir od�dlig enligt recover time och ifall den jagar blir den stilla st�ende
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
    public void Recover() // �terst�ller fiendens f�r och hastighet, plus g�r att den kan ta skada igen.
    {
        vulnerable = true;
        sprite.color = Color.white;
        if (chaser)
        {
            transform.GetChild(1).GetComponent<EnemyChase>().speed = ogSpeed;
        }
    }
    public void checkkdeath() // Ifall fienden inte har hp s� f�rsvinner den och droppar loot.
    {
        if (enemyhp < 1)
        {
            GetComponent<EnemyLootDrop>().DropLoot();
            Destroy(gameObject);
        }
    }
}
