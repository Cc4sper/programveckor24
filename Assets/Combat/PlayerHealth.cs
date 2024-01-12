using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    float maxHealth;
    public int armor = 0;
    public bool vulnerable = true;
    public Image healthBar;
    private void Start() 
    {
        maxHealth = health; //player allways starts with maxhealth
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            int damagetaken;
            damagetaken = collision.GetComponent<GenericAttack>().damage;
            if (vulnerable)
            {
                health -= damagetaken - armor;
                checkkdeath();
            }
        }
    }
    void checkkdeath()
    {
        if (health < 1)
        {
            print("dead");
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(20);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100;
    }

    public void HealHealth(float gain) //player heals _ health but if healing goes over max it sets health to max 
    {
        if (health + gain < maxHealth) 
        {
            health += gain;
        }
        else
        {
            health = maxHealth;
        }
    }
}
