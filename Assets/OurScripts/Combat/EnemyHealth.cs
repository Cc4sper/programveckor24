using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] int enemyhp;
    [SerializeField] float recoverTime;
    float timer;
    public bool vulnerable = true;
    private float ogSpeed;

    private void Start()
    {
        ogSpeed = transform.GetChild(1).GetComponent<EnemyChase>().speed;
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("damage") && vulnerable)
        {
            TakeDamage(collision.transform.GetComponent<GenericAttack>().damage, true);
        }
    }
   
    void TakeDamage(int dmg, bool hit)
    {
        vulnerable = false;
        print("hit enemy " + dmg);
        enemyhp -= dmg;
        checkkdeath();

        sprite.color = new Color(0.9f, 0.9f, 0.9f, 1);
        
        if (hit)
        {
            transform.GetChild(1).GetComponent<EnemyChase>().speed = 0;
        }
        timer = recoverTime;
    }
    private void Update()
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
    void Recover()
    {
        vulnerable = true;
        sprite.color = Color.white;
        transform.GetChild(1).GetComponent<EnemyChase>().speed = ogSpeed;
    }
    void checkkdeath()
    {
        if (enemyhp < 1)
        {
            GetComponent<EnemyLootDrop>().DropLoot();
            Destroy(gameObject);
        }
    }
}
