using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    float maxHealth;

    [SerializeField] float respawnTime;
    [SerializeField] GameObject screen;

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
    private void checkkDeath()
    {
        if (health < 1)
        {
            DisablePlayer();
            screen.GetComponent<DarkScreen>().ScreenFade();
            GetComponent<PlayerHotbarControl>().Hotbar.GetComponent<HotbarCollect>().Invoke("DropRandomItem", respawnTime);
            Invoke("Respawn", respawnTime);
            
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
        checkkDeath();

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

    private void DisablePlayer()
    {
        GetComponent<PlayerMove>().enabled = false;
        GetComponent<PlayerPickup>().enabled = false;
    }

    private void EnablePlayer()
    {
        GetComponent<PlayerMove>().enabled = true;
        GetComponent<PlayerPickup>().enabled = true;
    }
    private void Respawn()
    {
        HealHealth(maxHealth);
        EnablePlayer(); 
        transform.position = GetComponent<PlayerRespawn>().savedPos; //respawns at respawnpoint
    }
}
