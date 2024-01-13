using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] int enemyhp;
    [SerializeField] float recoverTime;
    public bool vulnerable = true;
    private float ogSpeed;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("damage") && vulnerable)
        {            
            TakeDamage(collision.GetComponent<GenericAttack>().damage,true);
        }
    }
    void TakeDamage(int dmg, bool hit)
    {
        vulnerable = false;
        print("hit enemy " + dmg);
        enemyhp -= dmg;
        checkkdeath();

        sprite.color = new Color(0.9f, 0.9f, 0.9f, 1);
        ogSpeed = GetComponent<EnemyChase>().speed;
        if (hit)
        {
            GetComponent<EnemyChase>().speed = 0;
        }
        Invoke("Recover", recoverTime);
    }
    void Recover()
    {
        vulnerable = true;
        sprite.color = Color.white;
        GetComponent<EnemyChase>().speed = ogSpeed;
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
