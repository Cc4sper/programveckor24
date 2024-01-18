using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //public float delay; Maybe later??
    public GameObject attackPrefab;
    public int enemyDamage;
    public float cooldown;
    public bool canAttack;
    public float timer;
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canAttack == true && collision.CompareTag("Player"))
        {
            print("enemy attack");
            Attack();
        }
    }

    public void Attack()
    {
        timer = cooldown;
        GameObject newStrike = Instantiate(attackPrefab, transform.position,Quaternion.identity);
        newStrike.tag = "Danger"; //marks it as not a enemy attack
        newStrike.GetComponent<GenericAttack>().damage = enemyDamage;
        
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            canAttack = false;
        }
        else if (canAttack == false)
        {
            canAttack = true;
        }
    }
}
