using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public int armor = 0;
    public bool vulnerable = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("damage"))
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
}
