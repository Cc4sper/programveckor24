using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyhp;
    [SerializeField] float recoverTime;
    public bool vulnerable = true;
    private float ogSpeed;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("damage") && vulnerable)
        {            
            Damage(collision.GetComponent<GenericAttack>().damage,true);
        }
    }
    void Damage(int dmg, bool hit)
    {
        vulnerable = false;
        print("hit enemy " + dmg);
        enemyhp -= dmg;
        checkkdeath();

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
        GetComponent<EnemyChase>().speed = ogSpeed;
    }
    void checkkdeath()
    {
        if (enemyhp < 1)
        {
            Destroy(gameObject);
            print("deadasss");
        }
    }
}
