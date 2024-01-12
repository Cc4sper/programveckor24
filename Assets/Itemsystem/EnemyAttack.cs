using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float delay;
    public GameObject attackPrefab;
    public int enemyDamage;
    public float reach;
    public float attackForce;
    public float cooldown;
    bool canAttack;
    float timer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canAttack == true)
        {
            print("enemy attack");
            Attack();
        }
        else
        {
            print("cant attack");
        }
    }

    public void Attack()
    {
        GameObject newStrike = Instantiate(attackPrefab, transform.position + transform.up * reach,Quaternion.identity);
        newStrike.tag = "Danger"; //marks it as not a enemy attack
        newStrike.GetComponent<Rigidbody2D>().AddForce(transform.up * attackForce, ForceMode2D.Force);
        newStrike.GetComponent<GenericAttack>().damage = enemyDamage;
        
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (canAttack == false)
        {
            canAttack = true;
        }
    }
}
