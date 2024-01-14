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
        if (collision.gameObject.CompareTag("Danger") && vulnerable)
        {
            TakeDamage(collision.GetComponent<GenericAttack>().damage);
        }
    }
    void checkkdeath()
    {
        if (health < 1)
        {
            print("player died");
            HealHealth(maxHealth);
            transform.position = GetComponent<PlayerRespawn>().savedPos;
           
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            HealHealth(5);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage - armor;
        UpdateHealthBar();
        checkkdeath();

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
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = health / 100;
    }
}
